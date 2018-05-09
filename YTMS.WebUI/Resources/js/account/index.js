var vm = new Vue({
    el: '#app',
    data: {
        isPosting: false,
        keyword: null,
        totalCount: 0,
        pageSize: 20,
        pageIndex: 1,
        tableData: [],
        dialogFormVisible: false,
        dialogFromIsAdd: true,
        currentRowIndex: null,
        form: {
            Id: null,
            Account: '',
            Password: '',
            Confirm:'',
            Name: '',
            Sex: 'male',
            Phone: '',
            WxChat: ''
        },
        dialogResetVisible: false,
        form2: {
            pwd: '',
            repwd: ''
        },
        dialogAuthorityVisible: false,
        formLabelWidth: '120px',
    },
    methods: {
        formatDate: function (str) {
            var _date = Utils.parseDate(str);
            return Utils.dataFormat(_date, 'yyyy-MM-dd HH:mm:ss')
        },
        getList: function () {
            var filter = {
                keywords: this.keyword,
                pageIndex: this.pageIndex,
                pageSize: this.pageSize
            };

            $.post(buildUrl('~/Account/GetList'), filter, function (res) {
                if (res.error) {
                    Msg.alert(res.error.message);
                    return;
                }

                if (res.value.TotalCount > 0) {
                    res.value.Rows.map(function (item, index) {
                        item.CreateTime = vm.formatDate(item.CreateTime);
                    });
                }

                vm.tableData = res.value.Rows;
                vm.totalCount = res.value.TotalCount;
            });
        },
        showAdminOptView: function (row,index) {
            this.dialogFormVisible = true;
            if (row) {
                this.dialogFromIsAdd = false;
                this.form.Id = row.Id;
                this.form.Account = row.Account;
                this.form.Name = row.Name;
                this.form.Sex = row.Sex;
                this.form.Phone = row.Phone;
                this.form.WxChat = row.WxChat;
            }
            else {
                this.dialogFromIsAdd = true;
            }

            this.currentRowIndex = index || null;
        },
        editAdmin: function (row) { },
        deleteAdmin: function (row) { },
        editPwd: function (row) {

        },
        closeOptView: function () {
            this.form.Id = null;
            this.form.Account = '';
            this.form.Name = '';
            this.form.Sex = 'male';
            this.form.Phone = '';
            this.form.WxChat = '';
            this.currentRowIndex = null;
            dialogFormVisible = false;
        },
        flipPage: function (page) {
            this.pageIndex = page;
            this.getList();
        },
        save: function () {
            var filter = this.form;
            var index = this.currentRowIndex;
            $.post(buildUrl('~/Account/Save'), filter, function (res) {
                if (res.error) {
                    Msg.alert(res.error.message);
                    return;
                }


                if (filter.Id) {
                    vm.tableData[index].Id = res.value.Id;
                    vm.tableData[index].Account = res.value.Account;
                    vm.tableData[index].Name = res.value.Name;
                    vm.tableData[index].Sex = res.value.Sex;
                    vm.tableData[index].Phone = res.value.Phone;
                    vm.tableData[index].WxChat = res.value.WxChat;
                } else {
                    var start = vm.tableData.length - 1;
                    vm.tableData.splice(start, 0, res.value);
                }
                vm.closeOptView();
                Msg.prompt('保存成功');
            });
        }
    },
    created: function () {
        this.getList();
    }
});