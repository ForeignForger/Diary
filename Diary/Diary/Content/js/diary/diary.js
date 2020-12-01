Diary = function (modeKey, diaryContainer, contentContainer) {
    var self = this;
    var settings = {
        filters: {
            from: null,
            to: null,
            noteTypes: []
        },
        diaryContainer: diaryContainer,
        contentContainer: contentContainer,
        url: "Diary/GetDiaryContent"
    };

    var viewMode = selectViewMode(modeKey);
    var noteService = new NoteService();
    var popupService = new DiaryPopupService;

    this.init = function () {
        popupService.init();
        viewMode.init();
        initViewModeSelection();
        initFilters();
        initActions();
        self.loadDiary();
    };

    this.loadDiary = function loadDiary() {
        var data = {
            mode: viewMode.key,
            from: settings.filters.from,
            to: settings.filters.to,
            noteTypes: settings.filters.noteTypes
        };
        var jsonData = JSON.stringify(data);

        $.ajax({
            url: settings.url,
            type: "POST",
            contentType: "application/json",
            data: jsonData,
            success: function (response) {
                insertDiaryContent(response)
            },
            error: function () {
                alert("Couldn't change view mode!");
            }
        });
    };

    function selectViewMode(modeKey) {
        if (modeKey == "day-mode") {
            return new DayViewMode(self);
        } else if (modeKey == "list-mode") {
            return new ListViewMode(self);
        }

        return undefined;
    }

    function initViewModeSelection() {
        $("#view-mode-select").change(function () {
            var optionSelected = $("option:selected", this);
            var newModeKey = optionSelected[0].value;
            var oldModeKey = viewMode ? viewMode.key : "";
            viewMode = selectViewMode(newModeKey);
            self.loadDiary();

            $(settings.diaryContainer).removeClass(oldModeKey).addClass(newModeKey);
        });
    }

    function initFilters() {
        $("#from-date").change(function () {
            var fromDate = $("#from-date")[0].value;
            settings.filters.from = fromDate;
        });

        $("#to-date").change(function () {
            var toDate = $("#to-date")[0].value;
            settings.filters.to = toDate;
        });

        $(".filter-note-type .checkboxes input").change(function () {
            var index = settings.filters.noteTypes.indexOf(this.value);
            if (this.checked) {
                if (index == -1) {
                    settings.filters.noteTypes.push(this.value);
                }            
            }
            else {
                if (index != -1) {
                    settings.filters.noteTypes.splice(index, 1);
                } 
            }
        });

        $(".filter-button").click(function () {
            self.loadDiary();
        });

    }

    function initActions() {
        $(".diary .controls .actions .note-create-button").click(function () {
            var noteType = $(this).attr("data-type");
            noteService.getCreateForm(noteType, initCreatePopup, function () { alert("Couldn't get popup data!"); });  
        });
    }

    function initCreatePopup(html) {
        popupService.showPopup(html);
        $(popupService.selectors.popupContent + " form").on('submit', function (e) {
            var noteType = $(popupService.selectors.popupContent + " .form-body").attr("data-type");
            var dataString = $(this).serialize();
            noteService.createNote(noteType, dataString, function (html) {
                initCreatePopup(html);
                self.loadDiary();
            }, function () {
                alert("Couldn't create " + noteType + "!");
            });
            e.preventDefault();
        });
    }

    function insertDiaryContent(html) {
        $(settings.contentContainer).html(html);

        $(".note-delete-button").click(function () {
            var id = $(this).attr("data-id");
            var onSuccess = self.loadDiary;

            var onFail = function () {
                alert("Couldn't delete note!");
            };

            noteService.deleteNote(id, onSuccess, onFail);
        });

        $(".note-set_status-button").click(function () {
            var id = $(this).attr("data-id");
            var status = $(this).attr("data-status");
            var onSuccess = self.loadDiary;

            var onFail = function () {
                alert("Couldn't update status!");
            };

            noteService.setStatus(id, status, onSuccess, onFail);
        });

        $(".note-update-button").click(function () {
            var id = $(this).attr("data-id");
            var noteType = $(this).attr("data-type");

            noteService.getUpdateForm(noteType, id, initUpdatePopup, function () { alert("Couldn't get popup data!"); });  
        });

        viewMode.setup(this);
    }

    function initUpdatePopup(html) {
        popupService.showPopup(html);
        $(popupService.selectors.popupContent + " form").on('submit', function (e) {
            var dataString = $(this).serialize();
            var noteType = $(popupService.selectors.popupContent + " .form-body").attr("data-type");

            noteService.updateNote(noteType, dataString, function (html) {
                initUpdatePopup(html);
                self.loadDiary();
            }, function () {
                alert("Couldn't update note!");
            });
            e.preventDefault();
        });
    }
};