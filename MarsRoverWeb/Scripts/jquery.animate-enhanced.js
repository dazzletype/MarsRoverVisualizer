﻿/*
jquery.animate-enhanced plugin v0.86
---
http://github.com/benbarnett/jQuery-Animate-Enhanced
http://benbarnett.net
@benpbarnett
*/
(function (d, z, A) {
    function E(a, b, j, c) { var f = F.exec(b), e = "auto" === a.css(j) ? 0 : a.css(j), e = "string" == typeof e ? w(e) : e; "string" == typeof b && w(b); var c = !0 === c ? 0 : e, d = a.is(":hidden"), h = a.translation(); "left" == j && (c = parseInt(e, 10) + h.x); "right" == j && (c = parseInt(e, 10) + h.x); "top" == j && (c = parseInt(e, 10) + h.y); "bottom" == j && (c = parseInt(e, 10) + h.y); !f && "show" == b ? (c = 1, d && a.css({ display: "block", opacity: 0 })) : !f && "hide" == b && (c = 0); return f ? (a = parseFloat(f[2]), f[1] && (a = ("-=" === f[1] ? -1 : 1) * a + parseInt(c, 10)), a) : c } function G(a, b,
j, c, f, e, g, h) { var i = a.data(q), i = i && !u(i) ? i : d.extend(!0, {}, H), n = f; if (-1 < d.inArray(b, x)) { var o = i.meta, m = w(a.css(b)) || 0, l = b + "_o", n = f - m; o[b] = n; o[l] = "auto" == a.css(b) ? 0 + n : m + n || 0; i.meta = o; g && 0 === n && (n = 0 - o[l], o[b] = n, o[l] = 0) } return a.data(q, I(a, i, b, j, c, n, e, g, h)) } function I(a, b, d, c, f, e, g, h, i) {
    var n = !1, g = !0 === g && !0 === h, b = b || {}; if (!b.original) b.original = {}, n = !0; b.properties = b.properties || {}; b.secondary = b.secondary || {}; for (var h = b.meta, o = b.original, m = b.properties, q = b.secondary, p = l.length - 1; 0 <= p; p--) {
        var k = l[p] +
"transition-property", r = l[p] + "transition-duration", s = l[p] + "transition-timing-function", d = g ? l[p] + "transform" : d; n && (o[k] = a.css(k) || "", o[r] = a.css(r) || "", o[s] = a.css(s) || ""); q[d] = g ? (!0 === i || !0 === y && !1 !== i) && B ? "translate3d(" + h.left + "px, " + h.top + "px, 0)" : "translate(" + h.left + "px," + h.top + "px)" : e; m[k] = (m[k] ? m[k] + "," : "") + d; m[r] = (m[r] ? m[r] + "," : "") + c + "ms"; m[s] = (m[s] ? m[s] + "," : "") + f
    } return b
} function J(a) { for (var b in a) if (("width" == b || "height" == b) && ("show" == a[b] || "hide" == a[b] || "toggle" == a[b])) return !0; return !1 }
    function u(a) { for (var b in a) return !1; return !0 } function w(a) { return parseFloat(a.replace(/px/i, "")) } function K(a, b, j) { var c = -1 < d.inArray(a, L); if (("width" == a || "height" == a) && b === parseFloat(j.css(a))) c = !1; return c } var L = "top,right,bottom,left,opacity,height,width".split(","), x = ["top", "right", "bottom", "left"], l = ["", "-webkit-", "-moz-", "-o-"], M = ["avoidTransforms", "useTranslate3d", "leaveTransforms"], F = /^([+-]=)?([\d+-.]+)(.*)$/, N = /([A-Z])/g, H = { secondary: {}, meta: { top: 0, right: 0, bottom: 0, left: 0} }, q = "jQe", C =
null, t = (document.body || document.documentElement).style, v = void 0 !== t.WebkitTransition ? "webkitTransitionEnd" : void 0 !== t.OTransition ? "oTransitionEnd" : "transitionend", D = void 0 !== t.WebkitTransition || void 0 !== t.MozTransition || void 0 !== t.OTransition || void 0 !== t.transition, B = "WebKitCSSMatrix" in window && "m11" in new WebKitCSSMatrix, y = B; if (d.expr && d.expr.filters) C = d.expr.filters.animated, d.expr.filters.animated = function (a) { return d(a).data("events") && d(a).data("events")[v] ? !0 : C.call(this, a) }; d.extend({ toggle3DByDefault: function () {
    y =
!y
} 
}); d.fn.translation = function () { if (!this[0]) return null; var a = window.getComputedStyle(this[0], null), b = { x: 0, y: 0 }; if (a) for (var d = l.length - 1; 0 <= d; d--) { var c = a.getPropertyValue(l[d] + "transform"); if (c && /matrix/i.test(c)) { a = c.replace(/^matrix\(/i, "").split(/, |\)$/g); b = { x: parseInt(a[4], 10), y: parseInt(a[5], 10) }; break } } return b }; d.fn.animate = function (a, b, j, c) {
    var a = a || {}, f = !("undefined" !== typeof a.bottom || "undefined" !== typeof a.right), e = d.speed(b, j, c), g = this, h = 0, i = function () {
        h--; 0 === h && "function" === typeof e.complete &&
e.complete.apply(g[0], arguments)
    }; return !D || u(a) || J(a) || 0 >= e.duration || !0 === d.fn.animate.defaults.avoidTransforms && !1 !== a.avoidTransforms ? z.apply(this, arguments) : this[!0 === e.queue ? "queue" : "each"](function () {
        var b = d(this), c = d.extend({}, e), g = function () {
            var c = b.data(q) || {}, d = {}; if (!0 !== a.leaveTransforms) { for (var e = l.length - 1; 0 <= e; e--) d[l[e] + "transform"] = ""; if (f && "undefined" !== typeof c.meta) for (var e = 0, g; g = x[e]; ++e) d[g] = c.meta[g + "_o"] + "px" } b.unbind(v).css(c.original).css(d).data(q, null); "hide" === a.opacity &&
b.css({ display: "none", opacity: "" }); i.call(b)
        }, j = { bounce: "cubic-bezier(0.0, 0.35, .5, 1.3)", linear: "linear", swing: "ease-in-out", easeInQuad: "cubic-bezier(0.550, 0.085, 0.680, 0.530)", easeInCubic: "cubic-bezier(0.550, 0.055, 0.675, 0.190)", easeInQuart: "cubic-bezier(0.895, 0.030, 0.685, 0.220)", easeInQuint: "cubic-bezier(0.755, 0.050, 0.855, 0.060)", easeInSine: "cubic-bezier(0.470, 0.000, 0.745, 0.715)", easeInExpo: "cubic-bezier(0.950, 0.050, 0.795, 0.035)", easeInCirc: "cubic-bezier(0.600, 0.040, 0.980, 0.335)",
            easeInBack: "cubic-bezier(0.600, -0.280, 0.735, 0.045)", easeOutQuad: "cubic-bezier(0.250, 0.460, 0.450, 0.940)", easeOutCubic: "cubic-bezier(0.215, 0.610, 0.355, 1.000)", easeOutQuart: "cubic-bezier(0.165, 0.840, 0.440, 1.000)", easeOutQuint: "cubic-bezier(0.230, 1.000, 0.320, 1.000)", easeOutSine: "cubic-bezier(0.390, 0.575, 0.565, 1.000)", easeOutExpo: "cubic-bezier(0.190, 1.000, 0.220, 1.000)", easeOutCirc: "cubic-bezier(0.075, 0.820, 0.165, 1.000)", easeOutBack: "cubic-bezier(0.175, 0.885, 0.320, 1.275)", easeInOutQuad: "cubic-bezier(0.455, 0.030, 0.515, 0.955)",
            easeInOutCubic: "cubic-bezier(0.645, 0.045, 0.355, 1.000)", easeInOutQuart: "cubic-bezier(0.770, 0.000, 0.175, 1.000)", easeInOutQuint: "cubic-bezier(0.860, 0.000, 0.070, 1.000)", easeInOutSine: "cubic-bezier(0.445, 0.050, 0.550, 0.950)", easeInOutExpo: "cubic-bezier(1.000, 0.000, 0.000, 1.000)", easeInOutCirc: "cubic-bezier(0.785, 0.135, 0.150, 0.860)", easeInOutBack: "cubic-bezier(0.680, -0.550, 0.265, 1.550)"
        }, p = {}, j = j[c.easing || "swing"] ? j[c.easing || "swing"] : c.easing || "swing", k; for (k in a) if (-1 === d.inArray(k,
M)) { var r = -1 < d.inArray(k, x), s = E(b, a[k], k, r && !0 !== a.avoidTransforms); !0 !== a.avoidTransforms && K(k, s, b) ? G(b, k, c.duration, j, r && !0 === a.avoidTransforms ? s + "px" : s, r && !0 !== a.avoidTransforms, f, !0 === a.useTranslate3d) : p[k] = a[k] } b.unbind(v); if ((k = b.data(q)) && !u(k) && !u(k.secondary)) { h++; b.css(k.properties); var t = k.secondary; setTimeout(function () { b.bind(v, g).css(t) }) } else c.queue = !1; u(p) || (h++, z.apply(b, [p, { duration: c.duration, easing: d.easing[c.easing] ? c.easing : d.easing.swing ? "swing" : "linear", complete: i, queue: c.queue}]));
        return !0
    })
}; d.fn.animate.defaults = {}; d.fn.stop = function (a, b, j) {
    if (!D) return A.apply(this, [a, b]); a && this.queue([]); this.each(function () {
        var c = d(this), f = c.data(q); if (f && !u(f)) {
            var e, g = {}; if (b) { if (g = f.secondary, !j && void 0 !== typeof f.meta.left_o || void 0 !== typeof f.meta.top_o) { g.left = void 0 !== typeof f.meta.left_o ? f.meta.left_o : "auto"; g.top = void 0 !== typeof f.meta.top_o ? f.meta.top_o : "auto"; for (e = l.length - 1; 0 <= e; e--) g[l[e] + "transform"] = "" } } else if (!u(f.secondary)) {
                var h = window.getComputedStyle(c[0], null);
                if (h) for (var i in f.secondary) if (f.secondary.hasOwnProperty(i) && (i = i.replace(N, "-$1").toLowerCase(), g[i] = h.getPropertyValue(i), !j && /matrix/i.test(g[i]))) { e = g[i].replace(/^matrix\(/i, "").split(/, |\)$/g); g.left = parseFloat(e[4]) + parseFloat(c.css("left")) + "px" || "auto"; g.top = parseFloat(e[5]) + parseFloat(c.css("top")) + "px" || "auto"; for (e = l.length - 1; 0 <= e; e--) g[l[e] + "transform"] = "" } 
            } c.unbind(v).css(f.original).css(g).data(q, null)
        } else A.apply(c, [a, b])
    }); return this
} 
})(jQuery, jQuery.fn.animate, jQuery.fn.stop);