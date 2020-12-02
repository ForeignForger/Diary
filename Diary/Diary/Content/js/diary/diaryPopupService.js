DiaryPopupService = function () {
    var self = this;
    self.selectors = {
        popup: ".diary-popup",
        popupContent: ".diary-popup .popup-content .content",
    };

    self.init = function () {
        $(self.selectors.popup).removeClass("active");
        $(".popup-close-button").click(function () {
            $(self.selectors.popup).removeClass("active");
            $(self.selectors.popupContent).html();
        });
    };

    self.showPopup = function (content) {
        $(self.selectors.popup).addClass("active");
        $(self.selectors.popupContent).html(content);
    };
};