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