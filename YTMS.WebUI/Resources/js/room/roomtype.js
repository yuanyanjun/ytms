
var vm = new Vue({
    el: '#app',
    data: {
        isPosting: false,
        tableData: [
            {
                Id: null,
                Name: '',
                Sort: '',
                CreateBy: '',
                CreateTime: '',
                isEdit: true
            }
        ]
    },
    computed: {},
    methods: {
        formatDate: function (str) {
            var _date = Utils.parseDate(str);
            return Utils.dataFormat(_date, 'yyyy-MM-dd HH:mm:ss')
        },
        getList: function () {
            $.get(buildUrl('~/RoomMgr/GetRoomTypeList'), {}, function (res) {
                if (res.error) {
                    Msg.alert(res.error.message);
                    return;
                }

                if (!res.value || res.value.length == 0)
                    return;

                vm.tableData = res.value;

                vm.tableData.map(function (item, index) {
                    vm.$set(item, 'isEdit', false);
                    vm.$set(item, 'isAdd', false);//dataFormat
                    if (item.CreateTime) {
                        vm.$set(item, 'CreateTime', vm.formatDate(item.CreateTime));
                    }

                })
                vm.tableData.push({
                    Name: '',
                    Sort: '',
                    CreateBy: '',
                    CreateTime: '',
                    isEdit: true,
                    isAdd: true
                });
            });
        },
        save: function (row, index) {

            if (vm.isPosting) {
                Msg.prompt('您手速太快，请稍后...');
                return;
            }

            if (!row.Name) {
                Msg.prompt('项目名称不能为空');
                return;
            }

            if (!row.Sort) {
                Msg.prompt('排序号不能为空');
                return;
            }
            if (isNaN(row.Sort) || row.Sort <= 0) {
                Msg.prompt('排序号只能为大于零的整数');
                return;
            }



            vm.isPosting = true;
            var filter = row;
            filter.__RequestVerificationToken = $G.__RequestVerificationToken;
            $.post(buildUrl('~/RoomMgr/SaveRoomType'), filter, function (res) {
                vm.isPosting = false;
                if (res.error) {
                    Msg.alert(res.error.message);
                    return;
                }

                if (row.Id) {
                    vm.tableData[index].Id = res.value.Id;
                    vm.tableData[index].Name = res.value.Name;
                    vm.tableData[index].Sort = res.value.Sort;
                    vm.tableData[index].CreateBy = res.value.CreateBy;
                    vm.tableData[index].CreateTime = vm.formatDate(res.value.CreateTime);
                    vm.tableData[index].isEdit = false;
                } else {
                    var start = vm.tableData.length - 2;
                    vm.tableData.splice(start, 0, {
                        Id: res.value.Id,
                        Name: res.value.Name,
                        Sort: res.value.Sort,
                        CreateBy: res.value.CreateBy,
                        CreateTime: vm.formatDate(res.value.CreateTime),
                        isEdit: false
                    });


                }
                //清空数
                vm.clearRow(vm.tableData.length - 1);
                vm.tableData.sort(function (a, b) {

                    if (!a.Sort || isNaN(a.Sort) || !b.Sort || isNaN(b.Sort))
                        return 0;

                    if (a.Sort < b.Sort) {
                        return -1;
                    } else if (a.Sort > b.Sort) {
                        return 1;
                    } else {
                        return 0;
                    }
                });
                Msg.prompt('保存成功');
            });
        },
        clearRow: function (index, id) {

            var isEdit = id != null && id != undefined;
            if (!isEdit) {
                vm.tableData[index].Id = null;
                vm.tableData[index].Name = '';
                vm.tableData[index].Sort = null;
                vm.tableData[index].CreateBy = null;
                vm.tableData[index].CreateTime = null;
            }

            vm.tableData[index].isEdit = !isEdit;
        },
        showEdit: function (index) {
            this.tableData[index].isEdit = true;

        },
        deleteRow: function (index) {

            if (vm.isPosting) {
                Msg.prompt('您手速太快，请稍后...');
                return;
            }

            Msg.confirm({
                title: '提示',
                text: '确定要删除此项目吗？',
                sureCallback: function () {
                    vm.isPosting = true;
                    var id = vm.tableData[index].Id;
                    var filter = {
                        __RequestVerificationToken: $G.__RequestVerificationToken,
                        id: id
                    }
                    $.post(buildUrl('~/RoomMgr/DeleteRoomType'), filter, function (res) {
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





        }
    },
    created: function () {
        this.getList();
    }
});