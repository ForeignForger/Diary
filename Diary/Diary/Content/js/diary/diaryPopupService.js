DiaryPopupService = function () {
    var selectors = {
        popup: ".diary-popup",
        popupContent: ".diary-popup .popup-content .content",
    }
    function init() {
        $(selectors.popup).removeClass("active");
        $(".popup-close-button").click(function () {
            $(selectors.popup).removeClass("active");
            $(selectors.popupContent).html();
        });
    }

    function showPopup(content) {
        $(selectors.popup).addClass("active");
        $(selectors.popupContent).html(content);
    }

    return {
        init: init,
        showPopup: showPopup
    }
}