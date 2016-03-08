using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace com.weixin.Model
{
    public class Template
    {
        #region 文本消息模板
        /// <summary>
        /// 模板静态字段
        /// </summary>
        private static string t_Template;

        /// <summary>
        /// 回复文本消息模板
        /// </summary>
        public static string TextTemplate
        {
            get
            {
                if (string.IsNullOrEmpty(t_Template))
                {
                    LoadTextTemplate();
                }

                return t_Template;
            }
        }

        /// <summary>
        /// 加载文本消息模板
        /// </summary>
        private static void LoadTextTemplate()
        {
            t_Template = @"<xml>
                                <ToUserName><![CDATA[{0}]]></ToUserName>
                                <FromUserName><![CDATA[{1}]]></FromUserName>
                                <CreateTime>{2}</CreateTime>
                                <MsgType><![CDATA[text]]></MsgType>
                                <Content><![CDATA[{3}]]></Content>
                            </xml>";
        }
        #endregion 

        #region 多客服消息模板
        /// <summary>
        /// 模板静态字段（多客服）
        /// </summary>
        private static string service_Template;

        /// <summary>
        /// 多客服消息模板
        /// </summary>
        public static string ServiceTemplate
        {
            get
            {
                if (string.IsNullOrEmpty(service_Template))
                {
                    LoadServiceTemplate();
                }

                return service_Template;
            }
        }

        /// <summary>
        /// 加载多客服消息模板
        /// </summary>
        private static void LoadServiceTemplate()
        {
            service_Template = @"<xml>
                                <ToUserName><![CDATA[{0}]]></ToUserName>
                                <FromUserName><![CDATA[{1}]]></FromUserName>
                                <CreateTime>{2}</CreateTime>
                                <MsgType><![CDATA[transfer_customer_service]]></MsgType>
                            </xml>";
        }
        #endregion 

        #region 图片消息模板
        /// <summary>
        /// 模板静态字段
        /// </summary>
        private static string i_Template;

        /// <summary>
        /// 回复图片消息模板
        /// </summary>
        public static string ImageTemplate
        {
            get
            {
                if (string.IsNullOrEmpty(i_Template))
                {
                    LoadImageTemplate();
                }

                return i_Template;
            }
        }

        /// <summary>
        /// 加载图片消息模板
        /// </summary>
        private static void LoadImageTemplate()
        {
            i_Template = @"<xml>
                                <ToUserName><![CDATA[{0}]]></ToUserName>
                                <FromUserName><![CDATA[{1}]]></FromUserName>
                                <CreateTime>{2}</CreateTime>
                                <MsgType><![CDATA[image]]></MsgType>
                                <Image>
                                    <MediaId><![CDATA[{3}]]></MediaId>
                                </Image>
                           </xml>";
        }
        #endregion 

        #region 语音消息模板
        /// <summary>
        /// 模板静态字段
        /// </summary>
        private static string v_Template;

        /// <summary>
        /// 回复语音消息模板
        /// </summary>
        public static string VoiceTemplate
        {
            get
            {
                if (string.IsNullOrEmpty(v_Template))
                {
                    LoadVoiceTemplate();
                }

                return v_Template;
            }
        }

        /// <summary>
        /// 加载语音消息模板
        /// </summary>
        private static void LoadVoiceTemplate()
        {
            v_Template = @"<xml>
                                <ToUserName><![CDATA[{0}]]></ToUserName>
                                <FromUserName><![CDATA[{1}]]></FromUserName>
                                <CreateTime>{2}</CreateTime>
                                <MsgType><![CDATA[voice]]></MsgType>
                                <Voice>
                                    <MediaId><![CDATA[{3}]]></MediaId>
                                </Voice>
                           </xml>";
        }
        #endregion 

        #region 视频消息模板
        /// <summary>
        /// 模板静态字段
        /// </summary>
        private static string vi_Template;

        /// <summary>
        /// 回复视频消息模板
        /// </summary>
        public static string VideoTemplate
        {
            get
            {
                if (string.IsNullOrEmpty(vi_Template))
                {
                    LoadVideoTemplate();
                }

                return vi_Template;
            }
        }

        /// <summary>
        /// 加载视频消息模板
        /// </summary>
        private static void LoadVideoTemplate()
        {
            vi_Template = @"<xml>
                                <ToUserName><![CDATA[{0}]]></ToUserName>
                                <FromUserName><![CDATA[{1}]]></FromUserName>
                                <CreateTime>{2}</CreateTime>
                                <MsgType><![CDATA[video]]></MsgType>
                                <Video>
                                    <MediaId><![CDATA[{3}]]></MediaId>
                                    <Title><![CDATA[{4}]]></Title>
                                    <Description><![CDATA[{5}]]></Description>
                                </Video> 
                             </xml>";
        }
        #endregion 

        #region 音乐消息模板
        /// <summary>
        /// 模板静态字段
        /// </summary>
        private static string m_Template;

        /// <summary>
        /// 回复音乐消息模板
        /// </summary>
        public static string MusicTemplate
        {
            get
            {
                if (string.IsNullOrEmpty(m_Template))
                {
                    LoadMusicTemplate();
                }

                return m_Template;
            }
        }

        /// <summary>
        /// 加载音乐消息模板
        /// </summary>
        private static void LoadMusicTemplate()
        {
            m_Template = @"<xml>
                                <ToUserName><![CDATA[{0}]]></ToUserName>
                                <FromUserName><![CDATA[{1}]]></FromUserName>
                                <CreateTime>{2}</CreateTime>
                                <MsgType><![CDATA[music]]></MsgType>
                                <Music>
                                    <Title><![CDATA[{3}]]></Title>
                                    <Description><![CDATA[{4}]]></Description>
                                    <MusicUrl><![CDATA[{5}]]></MusicUrl>
                                    <HQMusicUrl><![CDATA[{6}]]></HQMusicUrl>
                                    <ThumbMediaId><![CDATA[{7}]]></ThumbMediaId>
                                </Music>
                            </xml>";
        }
        #endregion 

        #region 图文消息模板
        /// <summary>
        /// 模板静态字段
        /// </summary>
        private static string n_Template;

        /// <summary>
        /// 回复图文消息模板
        /// </summary>
        public static string NewsTemplate
        {
            get
            {
                if (string.IsNullOrEmpty(n_Template))
                {
                    LoadNewsTemplate();
                }

                return n_Template;
            }
        }

        /// <summary>
        /// 加载图文消息模板
        /// </summary>
        private static void LoadNewsTemplate()
        {
            n_Template = @"<xml>
                                <ToUserName><![CDATA[{0}]]></ToUserName>
                                <FromUserName><![CDATA[{1}]]></FromUserName>
                                <CreateTime>{2}</CreateTime>
                                <MsgType><![CDATA[news]]></MsgType>
                                <ArticleCount>{3}</ArticleCount>
                                <Articles>{4}</Articles>
                           </xml>";
        }

           /// <summary>
        /// 模板静态字段
        /// </summary>
        private static string item_Template;

        /// <summary>
        /// 回复图文选项消息模板
        /// </summary>
        public static string ItemTemplate
        {
            get
            {
                if (string.IsNullOrEmpty(item_Template))
                {
                    LoadItemTemplate();
                }

                return item_Template;
            }
        }

        /// <summary>
        /// 加载图文选项消息模板
        /// </summary>
        private static void LoadItemTemplate()
        {
            item_Template = @"<item>
                                <Title><![CDATA[{0}]]></Title> 
                                <Description><![CDATA[{1}]]></Description>
                                <PicUrl><![CDATA[{2}]]></PicUrl>
                                <Url><![CDATA[{3}]]></Url>
                            </item>";
        }
        #endregion 

    }
}
