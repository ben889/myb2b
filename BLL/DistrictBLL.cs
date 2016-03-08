using Common;
using DAL;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    /// <summary>
    /// 区域
    /// </summary>
    public class DistrictBLL : CommonBLL<DistrictInfo>
    {
        public static string get_client_SQL(string distid, string tablename)
        {
            if (tablename.Trim().Length > 0)
                tablename = tablename + ".";
            string sql = "(" + tablename + "distid in (select distid from District where parentids like '%," + distid + ",%') or " + tablename + "distid=" + distid + ")";
            return sql;
        }
        public static string get_client_sellerid_in_SQL(string distid, string tablename)
        {
            string sql = "select sellerid from seller where " + get_client_SQL(distid, tablename);
            return sql;
        }

        public static int add(DistrictInfo info, ref string resultMsg)
        {
            if (info.Name.Trim().Length == 0)
            {
                resultMsg = "请填写名称";
                return 0;
            }
            bool exist_name = IsExist("Name='" + info.Name.Trim() + "'");
            if (exist_name)
            {
                resultMsg = info.Name + "已存在";
                return 0;
            }
            if (info.call_index != null && info.call_index.Trim().Length > 0)
            {
                bool exist_call_index = IsExist("call_index='" + info.call_index.Trim() + "'");
                if (exist_call_index)
                {
                    resultMsg = "调用代码" + info.call_index + "已存在";
                    return 0;
                }
            }
            info.PinYin = ChineseCharacter.HzConverToPy(info.Name);
            info.PinYinInitials = info.PinYin.Trim().Length > 0 ? info.PinYin.Substring(0, 1) : "";
            info.CreateTime = DateTime.Now;
            if (info.ParentId > 0)
            {
                info.ParentIds = "," + info.ParentId + get_parentids(info.ParentId);
            }
            int result = Insert(info, BS.Components.Data.Entity.ReturnTypes.Identity);
            if (result > 0)
            {
                info.DistId = result;
                if (info.ParentId == 0)
                {//是省份
                    info.ProvinceId = result;
                    info.ProvinceName = info.Name;
                    info.Level = 1;
                }
                else
                {
                    DistrictInfo dismodel = GetModel(info.ParentId);//查父级
                    if (dismodel != null)
                    {
                        if (dismodel.ParentId == 0)
                        {//如果父级的父级ID为0，则父级为省，此行应为城市
                            info.Level = 2;
                            info.ProvinceId = dismodel.ProvinceId;
                            info.ProvinceName = dismodel.ProvinceName;

                            info.CityId = result;
                            info.CityName = info.Name;
                        }
                        else
                        {
                            if (dismodel.CityId > 0 && dismodel.AreaId <= 0)
                            {
                                //为区域
                                info.Level = 3;

                                info.ProvinceId = dismodel.ProvinceId;
                                info.ProvinceName = dismodel.ProvinceName;

                                info.CityId = dismodel.CityId;
                                info.CityName = dismodel.CityName;

                                info.AreaId = result;
                                info.AreaName = info.Name;
                            }
                            else
                            {
                                //为商区
                                info.Level = 4;

                                info.ProvinceId = dismodel.ProvinceId;
                                info.ProvinceName = dismodel.ProvinceName;

                                info.CityId = dismodel.CityId;
                                info.CityName = dismodel.CityName;

                                info.AreaId = dismodel.AreaId;
                                info.AreaName = dismodel.AreaName;

                                info.DistrictId = result;
                                info.DistrictName = info.Name;
                            }
                        }
                    }
                }
                Update(info);
            }
            return result;
        }

        public static int update(DistrictInfo info, ref string resultMsg)
        {
            if (info.Name.Trim().Length == 0)
            {
                resultMsg = "请填写名称";
                return 0;
            }
            bool exist_name = IsExist("Name='" + info.Name.Trim() + "' and DistId<>" + info.DistId);
            if (exist_name)
            {
                resultMsg = info.Name + "已存在";
                return 0;
            }
            if (info.call_index != null && info.call_index.Trim().Length > 0)
            {
                bool exist_call_index = IsExist("call_index='" + info.call_index.Trim() + "' and DistId<>" + info.DistId);
                if (exist_call_index)
                {
                    resultMsg = "调用代码" + info.call_index + "已存在";
                    return 0;
                }
            }
            info.PinYin = ChineseCharacter.HzConverToPy(info.Name);
            info.PinYinInitials = info.PinYin.Trim().Length > 0 ? info.PinYin.Substring(0, 1) : "";
            info.ParentIds = get_parentids(info.DistId);
            int result = Update(info);
            if (result > 0)
            {
                if (info.ParentId == 0)
                { //批量更新省份数据
                    Update("District", "ProvinceName='" + info.ProvinceName + "'", "ProvinceId=" + info.ProvinceId);
                }
                else if (info.AreaId == 0)  //批量更新城市数据
                {
                    Update("District", "CityName='" + info.CityName + "'", "CityId=" + info.CityId);
                }
            }
            return result;
        }

        /// <summary>
        /// 递归查父ID
        /// </summary>
        /// <param name="DistId"></param>
        /// <returns></returns>
        public static string get_parentids(int DistId)
        {
            string result = "";
            if (DistId > 0)
            {
                int parentid = new DistrictDAL().get_parentid(DistId);
                if (parentid > 0)
                {
                    result = result + "," + parentid;
                    string pid = get_parentids(parentid);
                    if (pid.Trim().Length > 0)
                        result = result + pid;
                }
            }
            if (result.Trim().Length > 0 && !result.EndsWith(","))
                result = result + ",";
            return result;
        }

        public static int delete(int distid, ref string resultMsg)
        {
            if (distid <= 0)
                return 0;
            bool b = IsExist("parentid=" + distid);
            if (b)
            {
                resultMsg = "此区域已被使用";
                return 0;
            }
            return Delete(distid, "DistId");
        }


        public static List<DistrictInfo> get_citylist(int top, string where, string orderby)
        {
            try
            {
                string _where = "CityId>0 and ProvinceId>0 and AreaId=0";
                if (where.Trim().Length > 0)
                    _where = _where + " and " + where;
                return GetList(top, _where, orderby);
            }
            catch { }
            return null;
        }
    }
}
