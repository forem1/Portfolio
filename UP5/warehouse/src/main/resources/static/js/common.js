(function(e, t, n, r) {
    function o(t, n) {
        this.element = t;
        this.$element = e(t);
        this.options = e.extend({}, s, n);
        this._defaults = s;
        this._name = i, this.$topLevelBranches, this.$allBranches, this.init()
    }
    var i = "abixTreeList",
        s = {
            collapsedIconClass: "glyphicon glyphicon-plus",
            expandedIconClass: "glyphicon glyphicon-minus"
        };
    o.prototype.init = function() {
        var t = this;
        t.$topLevelBranches = t.$element.children("li");
        t.$allBranches = t.$element.find("li");
        t.$element.addClass("abix-tree-list");
        t.$allBranches.not(t.$topLevelBranches).hide();
        t.$allBranches.each(function() {
            var n = e(this).children("ul,ol");
            if (n.size() > 0) {
                e(this).addClass("collapsed");
                e('<span class="icon ' + t.options.collapsedIconClass + '"><\/span>').prependTo(e(this))
            }
        });
        t.$allBranches.children("span.icon").on("click", function(n) {
            if (e(this).parent().hasClass("collapsed")) {
                t.expand(e(this).parent());
                n.stopPropagation()
            }
            if (e(this).parent().hasClass("expanded")) {
                t.collapse(e(this).parent());
                n.stopPropagation()
            }
        });
        e("#tree-expand-all").on("click", function(e) {
            e.preventDefault();
            t.expandAll();
            e.stopPropagation()
        });
        e("#tree-collapse-all").on("click", function(e) {
            e.preventDefault();
            t.collapseAll();
            e.stopPropagation()
        })
    };
    o.prototype.expand = function(e) {
        var t = this;
        e.children("ul,ol").children("li").show(500, function() {
            e.removeClass("collapsed").addClass("expanded");
            e.children("span.icon").removeClass(t.options.collapsedIconClass).addClass(t.options.expandedIconClass)
        })
    };
    o.prototype.collapse = function(e) {
        var t = this;
        e.children("ul,ol").children("li").hide(500, function() {
            e.removeClass("expanded").addClass("collapsed");
            e.children("span.icon").removeClass(t.options.expandedIconClass).addClass(t.options.collapsedIconClass)
        })
    };
    o.prototype.collapseAll = function() {
        var e = this;
        e.$allBranches.not(e.$topLevelBranches).hide(1e3, function() {
            e.$allBranches.removeClass("expanded").addClass("collapsed");
            e.$allBranches.children("span.icon").removeClass(e.options.expandedIconClass).addClass(e.options.collapsedIconClass)
        })
    };
    o.prototype.expandAll = function() {
        var e = this;
        e.$allBranches.show(1e3, function() {
            e.$allBranches.removeClass("collapsed").addClass("expanded");
            e.$allBranches.children("span.icon").removeClass(e.options.collapsedIconClass).addClass(e.options.expandedIconClass)
        })
    };
    e.fn[i] = function(t) {
        return this.each(function() {
            if (!e.data(this, "plugin_" + i)) {
                e.data(this, "plugin_" + i, new o(this, t))
            }
        })
    }
})(jQuery, window, document)
$(document).ready(function() {
    $('#tree').abixTreeList();
});

//actions
$(document).ready(function() {
    $(".component-info-save").click(function(event){ //Sending request to index.php to update data about a component
        var ClickedComponentButtonSaveId = $(event.target)[0].id.replace('ComponentInfoSave_','');

        //alert(ClickedComponentButtonSaveId);
        //alert($("#ComponentFieldName_"+ClickedComponentButtonSaveId).val());
        $.get(
            "UpdateComponent",
            {"ComponentId" : ClickedComponentButtonSaveId, "ComponentName" : $("#ComponentFieldName_"+ClickedComponentButtonSaveId).val(), "ComponentFullName" : $("#ComponentFieldFullName_"+ClickedComponentButtonSaveId).val(), "ComponentSerial" : $("#ComponentFieldSerial_"+ClickedComponentButtonSaveId).val(), "ComponentAmount" : $("#ComponentFieldAmount_"+ClickedComponentButtonSaveId).val(), "ComponentUnit" : $("#ComponentFieldUnit_"+ClickedComponentButtonSaveId).val(), "ComponentLocation" : $("#ComponentFieldLocation_"+ClickedComponentButtonSaveId).val(), "ComponentTag" : $("#ComponentFieldTag_"+ClickedComponentButtonSaveId).val()}, //UCV - Update Component Value
            function(data) {
                //alert('page content: ' + data);
                alert("Сохранено");
            }
        );
    });

    $(".component-info-delete").click(function(event){ //Sending request to index.php to delete a component
        var ClickedComponentButtonDeleteId = $(event.target)[0].id.replace('ComponentInfoDelete_','');
        //alert(ClickedComponentButtonSaveId);
        if(confirm("Вы уверены, что хотите удалить компонент "+ClickedComponentButtonDeleteId+"?")) {
            $.get(
                "DeleteComponent",
                {"ComponentId" : ClickedComponentButtonDeleteId}, //DTC - Delete This Component
                function(data) {
                    //alert('page content: ' + data);
                    document.location.reload();
                }
            );
        }
    });

    $(".component-info-add").click(function(event){ //Sending request to index.php to add a new component

        //alert(ClickedComponentButtonSaveId);
        //alert($("#ComponentFieldName_"+ClickedComponentButtonSaveId).val());
        if($("#ComponentFieldAddName").val().length > 0 && $("#ComponentFieldAddFullName").val().length > 0 && $("#ComponentFieldAddAmount").val().length > 0 && $("#ComponentFieldAddUnit").val().length > 0 && $("#ComponentFieldAddLocation").val().length > 0 && $("#ComponentFieldAddGroup").val().length > 0) {
            $.get(
            "AddComponent",
            {"ComponentName" : $("#ComponentFieldAddName").val(), "ComponentFullName" : $("#ComponentFieldAddFullName").val(), "ComponentSerial" : $("#ComponentFieldAddSerial").val(), "ComponentAmount" : $("#ComponentFieldAddAmount").val(), "ComponentUnit" : $("#ComponentFieldAddUnit").val(), "ComponentLocation" : $("#ComponentFieldAddLocation").val(), "ComponentTag" : $("#ComponentFieldAddTag").val(), "ComponentGroup" : $("#ComponentFieldAddGroup").val()}, //ANC - Add New Component
            function(data) {
                //alert('page content: ' + data);
                document.location.reload();
            }
            );
        } else alert("Проверьте правильность заполнения полей");
    });

    $(".tree-class-add").click(function(event){ //Sending request to index.php to add a new class

        //alert("asd");
        //alert($("#ComponentFieldName_"+ClickedComponentButtonSaveId).val());
        if($("#ClassFieldAddName").val().length > 0) {
            $.get(
                "AddClass",
                {"ClassName" : $("#ClassFieldAddName").val()}, //ATC - Add Tree Class
                function(data) {
                    //alert('page content: ' + data);
                    document.location.reload();
                }
            );
        }
        else alert("Проверьте правильность заполнения полей");
    });

    $(".tree-category-add").click(function(event){ //Sending request to index.php to add a new category

        //alert($("#CategoryFieldAddClass").val());
        //alert($("#ComponentFieldName_"+ClickedComponentButtonSaveId).val());
        if($("#CategoryFieldAddName").val().length > 0 && $("#CategoryFieldAddClass").val().length > 0) {
            $.get(
                "AddCategory",
                {"CategoryName": $("#CategoryFieldAddName").val(), "CategoryClass": $("#CategoryFieldAddClass").val()}, //ATT - Add Tree caTegory
                function (data) {
                    //alert('page content: ' + data);
                    document.location.reload();
                }
            );
        } else alert("Проверьте правильность заполнения полей");
    });

    $(".tree-group-add").click(function(event) { //Sending request to index.php to add a new group
        //alert("asd");
        //alert($("#ComponentFieldName_"+ClickedComponentButtonSaveId).val());
        //alert($("#GroupFieldAddName").val());
        //alert($("#GroupFieldAddCategory").val());
        if($("#GroupFieldAddName").val().length > 0 && $("#GroupFieldAddCategory").val().length > 0) {
            $.get(
                "AddGroup",
                {"GroupName": $("#GroupFieldAddName").val(), "GroupCategory": $("#GroupFieldAddCategory").val()}, //ATG - Add Tree Group
                function (data) {
                    //alert('page content: ' + data);
                    document.location.reload();
                }
            );
        } else alert("Проверьте правильность заполнения полей");
    });

    setInterval(function(){ //Updating transactions table every 5 seconds if table is visible
        if($("#content-2").css('display') != "none") {
            //alert("asd");
            $.ajax({
                type: "GET",
                url: "GetTransactions",
                data: {}
            }).done(function( data ) {
                //alert(data)
                //alert( data.split('<')[0] );
                let obj = JSON.parse( data );

                $('#TransactionsTable tbody').empty();

                $.each(obj, function(i, item) {
                    $('#TransactionsTable > tbody:last-child').append("<tr><td>" + item.TransactionDate + "</td><td>" + item.ComponentName + "</td><td>" + item.TransactionDifferent + "</td><td>" + item.StaffName + "</td><td>" + item.TransactionPlace + "</td><td>" + item.TransactionNote + "</td></tr>");
                });
            });
        }
    }, 5000);

    $(".transaction-add-confirm").click(function(event){ //Sending request to index.php for add a new transaction

        //alert("Добавления нет, но вы держитесь. Оно появится, но не очень, а если и да, то может быть и нет.");
        //alert($("#ComponentFieldName_"+ClickedComponentButtonSaveId).val());
        if($("#TransactionFieldAddDate").val().length > 0 && $("#TransactionFieldAddDifferent").val().length > 0 && $("#TransactionFieldAddStaff").val().length > 0) {
            $.get(
                "AddTransaction",
                {"TransactionComponentId" : $("#TransactionFieldAddId").val(), "TransactionDate" : $("#TransactionFieldAddDate").val(), "TransactionDifferent" : $("#TransactionFieldAddDifferent").val(), "TransactionStaffId" : $("#TransactionFieldAddStaff").val(), "TransactionPlace" : $("#TransactionFieldAddPlace").val(), "TransactionNote" : $("#TransactionFieldAddNote").val()}, //ANT - Add New Transaction
                function(data) {
                    //alert('page content: ' + data);
                    document.location.reload();
                }
            );
        } else alert("Проверьте правильность заполнения полей");
    });

    $(".transaction-add").click(function(event){ //Opening transaction modal window handler
        var ClickedTransactionButtonAddId = $(event.target)[0].id.replace('TransactionAdd_','');
        //alert(ClickedTransactionButtonAddId);

        $('.component-info').modal('hide');
        $('#TransactionFieldAddId').val(ClickedTransactionButtonAddId);

    });
});