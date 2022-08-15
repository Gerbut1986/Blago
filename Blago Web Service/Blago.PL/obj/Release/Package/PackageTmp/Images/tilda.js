(function () {
    if ((/bot|google|yandex|baidu|bing|msn|duckduckbot|teoma|slurp|crawler|spider|robot|crawling|facebook/i.test(navigator.userAgent)) === false && typeof (sessionStorage) != 'undefined' && sessionStorage.getItem('visited') !== 'y' && document.visibilityState) {
        var style = document.createElement('style');
        style.type = 'text/css';
        style.innerHTML = '@media screen and (min-width: 980px) {.t-records {opacity: 0;}.t-records_animated {-webkit-transition: opacity ease-in-out .2s;-moz-transition: opacity ease-in-out .2s;-o-transition: opacity ease-in-out .2s;transition: opacity ease-in-out .2s;}.t-records.t-records_visible {opacity: 1;}}';
        document.getElementsByTagName('head')[0].appendChild(style);
        function t_setvisRecs() {
            var alr = document.querySelectorAll('.t-records');
            Array.prototype.forEach.call(alr, function (el) {
                el.classList.add("t-records_animated");
            });
            setTimeout(function () {
                Array.prototype.forEach.call(alr, function (el) {
                    el.classList.add("t-records_visible");
                });
                sessionStorage.setItem("visited", "y");
            }, 400);
        }
        document.addEventListener('DOMContentLoaded', t_setvisRecs);
    }
})();

t_onReady(function () {
    t_onFuncLoad('t396_init', function () {
        t396_init('457542507');
    });
});

t_onReady(function () {
    t_onFuncLoad('t396_init', function () {
        t396_init('460085182');
    });
});

t_onReady(function () {
    t_onFuncLoad('t396_init', function () {
        t396_init('460086115');
    });
});

t_onReady(function () {
    t_onFuncLoad('t396_init', function () {
        t396_init('460113681');
    });
});


function t_onReady(func) {
    if (document.readyState != 'loading') {
        func();
    } else {
        document.addEventListener('DOMContentLoaded', func);
    }
}
function t_onFuncLoad(funcName, okFunc, time) {
    if (typeof window[funcName] === 'function') {
        okFunc();
    } else {
        setTimeout(function () {
            t_onFuncLoad(funcName, okFunc, time);
        }, (time || 100));
    }
} function t_throttle(fn, threshhold, scope) { return function () { fn.apply(scope || this, arguments); }; }


function t_falladv__handleDomTimeOut() { var e, t; "loading" == document.readyState && "object" == typeof window.performance && null !== document.head.querySelector('script[src^="https://static.tildacdn."]') && (t = window.performance.getEntriesByType("resource"), e = "", t.forEach(function (t) { -1 < t.name.indexOf("https://static.tildacdn.") && 0 < t.startTime && (e = "ok") }), "ok" != e && (console.log("Force switching origin"), t = document.querySelectorAll("script,link,img"), Array.prototype.forEach.call(t, function (t) { t_falladv__reloadSRC(t) }), window.lazy_err_static = "y")) } function t_falladv__reloadSRC(t) { var e, n = t.tagName, c = "", o = ""; if (("LINK" == n || "SCRIPT" == n || "IMG" == n) && ("LINK" == n && (c = t.getAttribute("href")), "SCRIPT" != n && "IMG" != n || (c = t.getAttribute("src")), "string" == typeof c && (0 === c.indexOf("https://static.tildacdn.com/") ? o = c.replace("https://static.tildacdn.com/", "https://static3.tildacdn.com/") : 0 === c.indexOf("https://ws.tildacdn.com/") && (o = "/" + (c = c.split("/"))[c.length - 1]), 0 < o.indexOf("/css/fonts-tildasans") && (o = o.replace(".css", ".s3.css")), "" != o))) { if ("SCRIPT" == n) { if (null !== document.head.querySelector('script[src^="' + o + '"]')) return } else if ("LINK" == n && null !== document.head.querySelector('link[href^="' + o + '"]')) return; "LINK" == n ? ((e = window.document.createElement("link")).rel = "stylesheet", e.type = "text/css", e.href = o, e.media = "all", e.onload = function () { t.remove() }, document.head.appendChild(e)) : "SCRIPT" == n ? ((e = window.document.createElement("script")).async = !0, e.src = o, e.onload = function () { t.remove() }, document.head.appendChild(e)) : "IMG" == n && (t.src = o), console.log("Try to reload: " + o) } }


window.addEventListener('load', function () {
    t_onFuncLoad('t228_setWidth', function () {
        t228_setWidth('457542501');
    });
});
window.addEventListener('resize', t_throttle(function () {
    t_onFuncLoad('t228_setWidth', function () {
        t228_setWidth('457542501');
    });
    t_onFuncLoad('t_menu__setBGcolor', function () {
        t_menu__setBGcolor('457542501', '.t228');
    });
}));
t_onReady(function () {
    t_onFuncLoad('t_menu__highlightActiveLinks', function () {
        t_menu__highlightActiveLinks('.t228__list_item a');
    });
    t_onFuncLoad('t_menu__findAnchorLinks', function () {
        t_menu__findAnchorLinks('457542501', '.t228__list_item a');
    });
    t_onFuncLoad('t228__init', function () {
        t228__init('457542501');
    });
    t_onFuncLoad('t_menu__setBGcolor', function () {
        t_menu__setBGcolor('457542501', '.t228');
    });
    t_onFuncLoad('t228_setWidth', function () {
        t228_setWidth('457542501');
    });
    var rec = document.querySelector('#rec457542501');
    if (!rec) return;
    t_onFuncLoad('t_menu__showFixedMenu', function () {
        var el = rec.querySelector('.t228');
        if (el) el.classList.remove('t228__beforeready');
        t_menu__showFixedMenu('457542501', '.t228');
        window.addEventListener('scroll', t_throttle(function () {
            t_menu__showFixedMenu('457542501', '.t228');
        }));
    });
    t_onFuncLoad('t_menu__createMobileMenu', function () {
        t_menu__createMobileMenu('457542501', '.t228');
    });
});


t_onReady(function () {
    t_onFuncLoad('t396_init', function () {
        t396_init('460525473');
    });
});


if (!window.mainTracker) { window.mainTracker = 'tilda'; }
window.tildastatcookie = 'no';
setTimeout(function () {
    (function (d, w, k, o, g) { var n = d.getElementsByTagName(o)[0], s = d.createElement(o), f = function () { n.parentNode.insertBefore(s, n); }; s.type = "text/javascript"; s.async = true; s.key = k; s.id = "tildastatscript"; s.src = g; if (w.opera == "[object Opera]") { d.addEventListener("DOMContentLoaded", f, false); } else { f(); } })(document, window, 'a456b1d7c07548d7072586e660384672', 'script', 'https://static.tildacdn.info/js/tilda-stat-1.0.min.js');
}, 2000);