
var vm = new Vue({
    el: '#app',
    data: {
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
        getList: function () {
            $.get(buildUrl('~/RoomMgr/GetList'), {}, function (res) {
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
                        var _date = Utils.parseDate(item.CreateTime);
                        vm.$set(item, 'CreateTime', Utils.dataFormat(_date, 'yyyy-MM-dd HH:mm:ss'));
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
        }
    },
    created: function () {
        this.getList();
    }
});