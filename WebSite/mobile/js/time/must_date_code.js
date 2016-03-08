﻿(function (a) {
    var b = { weekText: ["周日", "周一", "周二", "周三", "周四", "周五", "周六"], daysCount: 15, };
    a.mobiscroll.presets.datehour = function (p) {
        var v = a.extend({}, p.settings), x = a.extend(p.settings, b, v), t = a(this);
        var l = new Date();
        var o = [];
        var e = { label: "日期", keys: [], values: [], };
        var w = { label: "时间", keys: [], values: [], };
        for (var k = 0; k < x.daysCount; k++) {
            var j = l.valueOf();
            j = j + k * 24 * 60 * 60 * 1000;
            j = new Date(j);
            var u = j.getFullYear();
            var g = j.getMonth() + 1;
            var r = j.getDate();
            var f = g + "月" + r + "日&nbsp;" + x.weekText[j.getDay()];
            if (g <= 9) {
                g = "0" + g
            }
            if (r <= 9) {
                r = "0" + r
            }
            var q = u + "-" + g + "-" + r;
            e.keys.push(q);
            if (k == 0) {
                f = "今天"
            } else {
                if (k == 1) {
                    f = "明天"
                }
            }
            e.values.push(f)
        }
        for (var n = 0; n <= 23; n++) {
            if (n <= 9) {
                n = "0" + n
            }
            w.keys.push(n + ":00", n + ":30");
        }
        for (var i = 0; i < w.keys.length; i++) {
            w.values.push(w.keys[i])
        }
        var c = [];
        c.push(e);
        c.push(w);
        o.push(c);
        return {
            wheels: o, parseValue: function (I, D) {
                console.info("parseValue:" + I);
                var B = new RegExp(/[0-9]{4}-[0-9]{2}-[0-9]{2}[" "]{1}[0-9]{2}[:]{1}[0-9]{2}/);
                if (I == null || I == "" || !B.test(I)) {
                    var H = new Date();
                    var C = H.getHours();
                    var s = H.getMinutes();
                    if (C >= 0 && C < 8 || (C == 8 && s == 0)) {
                        C = 10
                    } else {
                        if (C >= 8 && C < 17 || (C == 17 && s == 0)) {
                            if (s == 0) {
                                C = C + 2
                            } else {
                                C = C + 3
                            }
                        } else {
                            H = H.valueOf();
                            H = H + 24 * 60 * 60 * 1000;
                            H = new Date(H);
                            C = 10
                        }
                    }
                    if (C > 19) {
                        C = 19
                    }
                    var G = H.getFullYear();
                    var z = H.getMonth() + 1;
                    var F = H.getDate();
                    z = z <= 9 ? "0" + z : z;
                    F = F <= 9 ? "0" + F : F;
                    C = C <= 9 ? "0" + C : C;
                    I = G + "-" + z + "-" + F + " " + C + ":00";
                    console.info("defaultValue:" + I)
                }
                var h = I.split(" "), E = [], A = 0, J;
                a.each(D.settings.wheels, function (i, d) {
                    a.each(d, function (y, m) {
                        m = m.values ? m : convert(m);
                        J = m.keys || m.values;
                        if (a.inArray(h[A], J) !== -1) {
                            E.push(h[A])
                        } else {
                            E.push(J[0])
                        }
                        A++
                    })
                });
                return E
            }, validate: function (C, I) {
                var N = new Date();
                var s = N.getHours();
                var h = N.getMinutes();
                if (s >= 0 && s < 8 || (s == 8 && h == 0)) {
                    s = 10
                } else {
                    if (s >= 8 && s < 17 || (s == 17 && h == 0)) {
                        if (h == 0) {
                            s = s + 2
                        } else {
                            s = s + 2
                        }
                    } else {
                        N = N.valueOf();
                        N = N + 24 * 60 * 60 * 1000;
                        N = new Date(N);
                        s = 8
                    }
                }
                if (s > 19) {
                    s = 19
                }
                var B = N.getFullYear();
                var G = N.getMonth() + 1;
                var K = N.getDate();
                G = G <= 9 ? "0" + G : G;
                K = K <= 9 ? "0" + K : K;
                s = s <= 9 ? "0" + s : s;
                var E = B + "-" + G + "-" + K;
                var L = a(".dw-ul", C).eq(0);
                var D = a(".dw-ul", C).eq(1);
                var O = a(".dw-li", L).index(a('.dw-li[data-val="' + E + '"]', L)), M = a(".dw-li", L).size();
                a(".dw-li", L).removeClass("dw-v").slice(O, M).addClass("dw-v");
                var A = s + ":00", z = "23:00"; // 最大可选时间
                var J = p.temp;
                if (J[0] != E) {
                    A = "06:00" // 最小可选时间
                } else {
                    if (N.getHours() > 20 || (N.getHours() == 20 && h > 0)) {
                        A = "10:00"
                    }
                }
                var H = a(".dw-li", D).index(a('.dw-li[data-val="' + A + '"]', D)), F = a(".dw-li", D).index(a('.dw-li[data-val="' + z + '"]', D));
                a(".dw-li", D).removeClass("dw-v").slice(H, F + 1).addClass("dw-v")
            },
        }
    };
    a.mobiscroll.presetShort("datehour")
})(jQuery);