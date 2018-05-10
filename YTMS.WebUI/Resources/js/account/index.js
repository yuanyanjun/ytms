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
        form: {
            rowIndex: null,
            Id: null,
            Account: '',
            Password: '',
            Confirm: '',
            Name: '',
            Sex: 'male',
            Phone: '',
            WxChat: ''
        },
        dialogResetVisible: false,
        form2: {
            Id: null,
            Account: '',
            Password: '',
            RePassword: ''
        },
        formLabelWidth: '120px'
    },
    computed: {
        addViewTitle: function () {
            return this.dialogFromIsAdd ? '新增用户' : '修改用户';
        }
    },
    methods: {
        formatDate: function (str) {
            var _date = Utils.parseDate(str);
            return Utils.dataFormat(_date, 'yyyy-MM-dd HH:mm:ss')
        },
        tableRowFormat: function (row, col, colval, index) {

            if (!colval) return '';

            if (col.property == 'Sex') {
                if (colval == 'male') return '男';
                else if (colval == 'famale') return '女';
                else return colval;
            }
            else if (col.property == 'CreateTime') {
                return this.formatDate(colval);
            }
            return colval;
        },
        getList: function () {
            var filter = {
                __RequestVerificationToken: $G.__RequestVerificationToken,
                keywords: this.keyword,
                pageIndex: this.pageIndex,
                pageSize: this.pageSize
            };

            $.post(buildUrl('~/Account/GetList'), filter, function (res) {
                if (res.error) {
                    Msg.alert(res.error.message);
                    return;
                }



                vm.tableData = res.value.Rows;
                vm.totalCount = res.value.TotalCount;
            });
        },
        search: function () {
            this.pageIndex = 1;
            this.getList();
        },
        showAdminOptView: function (row, index) {

            this.dialogFormVisible = true;
            if (row) {
                this.dialogFromIsAdd = false;
                this.form.Id = row.Id;
                this.form.Account = row.Account;
                this.form.Name = row.Name;
                this.form.Sex = row.Sex;
                this.form.Phone = row.Phone;
                this.form.WxChat = row.WxChat;
                this.form.rowIndex = index;
            }
            else {
                this.dialogFromIsAdd = true;
            }
        },
        closeOptView: function () {

            this.form.Id = null;
            this.form.Account = '';

            if (this.dialogFromIsAdd) {
                this.form.Password = '';
                this.form.Confirm = '';
            }
            this.form.Name = '';
            this.form.Sex = 'male';
            this.form.Phone = '';
            this.form.WxChat = '';
            this.rowIndex = null;
            this.dialogFormVisible = false;
        },
        flipPage: function (page) {

            this.pageIndex = page;
            this.getList();
        },
        save: function () {

            if (vm.isPosting) {
                Msg.prompt('您手速太快，请稍后...');
                return;
            }

            var filter = this.form;
            var index = filter.rowIndex;

            if (!filter.Account) {
                Msg.prompt('登录账号不能为空');
                return;
            }
            if (this.dialogFromIsAdd) {
                if (!filter.Password) {
                    Msg.prompt('登录密码不能为空');
                    return;
                }
                if (!filter.Confirm) {
                    Msg.prompt('重复密码不能为空');
                    return;
                }

                if (filter.Password != filter.Confirm) {
                    Msg.prompt('两次输入的密码不一致');
                    return;
                }
            }

            if (!filter.Name) {
                Msg.prompt('真实姓名不能为空');
                return;
            }
            if (!filter.Phone) {
                Msg.prompt('手机号码不能为空');
                return;
            }

            vm.isPosting = true;
            filter['__RequestVerificationToken'] = $G.__RequestVerificationToken;
            $.post(buildUrl('~/Account/Save'), filter, function (res) {
                vm.isPosting = false;
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
                    var start = vm.tableData.length;
                    vm.tableData.splice(start, 0, res.value);
                }
                vm.closeOptView();
                Msg.prompt('保存成功');
            });
        },
        deleteRow: function (index) {
            if (vm.isPosting) {
                Msg.prompt('您手速太快，请稍后...');
                return;
            }

            Msg.confirm({
                title: '提示',
                text: '确定要删除此标签吗？',
                sureCallback: function () {
                    vm.isPosting = true;
                    var id = vm.tableData[index].Id;

                    var filter = {
                        __RequestVerificationToken: $G.__RequestVerificationToken,
                        id: id
                    }
                    $.post(buildUrl('~/Account/Remove'), filter, function (res) {
                        vm.isPosting = false;
                        if (res.error) {
                            Msg.alert(res.error.message);
                            return;
                        }
                        vm.tableData.splice(index, 1);
                        Msg.prompt('删除成功');
                    });
                },
                canelCallback: null,
            });
        },

        showRePwdView: function (row) {
            this.dialogResetVisible = true;
            this.form2.Id = row.Id;
            this.form2.Account = row.Account;
        },
        closeRePwdView: function () {
            this.dialogResetVisible = false;
            this.form2.Id = null;
            this.form2.Account = '';
            this.form2.Password = '';
            this.form2.RePassword = '';
        },
        resetPassword: function () {

            if (!this.form2.Password) {
                Msg.prompt('密码不能为空');
                return;
            }

            if (!this.form2.RePassword) {
                Msg.prompt('重复密码不能为空');
                return;
            }

            if (this.form2.Password != this.form2.RePassword) {
                Msg.prompt('两次输入密码不一致');
                return;
            }

            var filter = {
                __RequestVerificationToken: $G.__RequestVerificationToken,
                Id: this.form2.Id,
                Password: this.form2.Password
            };

            $.post(buildUrl('~/Account/ReSetPassword'), filter, function (res) {
                if (res.error) {
                    Msg.alert(res.error.message);
                    return;
                }
                vm.closeRePwdView();
                Msg.prompt('修改成功');
            });
        }
    },
    created: function () {
        this.getList();
    }
});

