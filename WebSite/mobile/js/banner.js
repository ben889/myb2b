$(function(){$.fn.banner()}),function(a){a.fn.banner=function(b){var c,d,e,f,g,h={t_id:"#banner",t_dlid:"silder",t_timeout:6e3,t_speed:600},i=a.extend(h,b),j=a(i.t_id+" .ban_list dl"),k=a(i.t_id+" .ban_list dl dd"),l=k.length;for(k.width(a(i.t_id).width()),j.width(l*k.width()),a(window).on("resize",function(){var b=(k.width(),a(i.t_id+" ul li.on").index());k.width(a(i.t_id).width()),j.width(l*k.width()),0!=b&&j.css("left",-b*k.width())}),c="<ul>",d=0;l>d;d++)c+="<li></li>";for(a(i.t_id).append(c),a(i.t_id+" ul li:first").addClass("on"),e=0,f=a(i.t_id+" ul li"),d=0;d<f.length;d++)!function(){var a=d;f[d].onclick=function(){return g.slide(a),!1}}();g=new TouchSlider({id:i.t_dlid,speed:i.t_speed,timeout:i.t_timeout,loop:!0,before:function(a){f[e].className="",e=a,f[e].className="on"}})}}(jQuery);