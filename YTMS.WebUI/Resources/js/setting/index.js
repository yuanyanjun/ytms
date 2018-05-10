var vm = new Vue({
    el: '#app',
    data: {
        configData: {
            Proportion: null,
            FixedLoss: 0.00,
            PlatformPoint: 0,
            FloorEarnings: 0.00,
            RoomCoverMaxNum: 0
        },
        isPosting: false
    },
    computed: {},
    methods: {
        get: function () {
            $.get(buildUrl('~/Setting/GetSysConfig'), {}, function (res) {
                if (res.error) {
                    Msg.alert(res.error.message);
                    return;
                }
                if (res.value) {
                    vm.configData = res.value;
                }
            });
        },
        set: function () {

            if (this.isPosting) {
                Msg.prompt('您手速太快，请稍后...');
                return;
            }

            if (!this.configData.Proportion || isNaN(this.configData.Proportion)) {
                Msg.alert('业主分成比例不能为空');
                return;
            }
            if (!this.configData.FixedLoss || isNaN(this.configData.FixedLoss)) {
                Msg.alert('固定损耗不能为空');
                return;
            }
            if (!this.configData.PlatformPoint || isNaN(this.configData.PlatformPoint)) {
                Msg.alert('平台扣点不能为空');
                return;
            }
            if (!this.configData.RoomCoverMaxNum || isNaN(this.configData.RoomCoverMaxNum)) {
                Msg.alert('海报最大上次数量不能为空');
                return;
            }
            if (!this.configData.FloorEarnings || isNaN(this.configData.FloorEarnings)) {
                Msg.alert('业主保底分成不能为空');
                return;
            }



            this.isPosting = true;
            var filter = this.configData;
            filter.__RequestVerificationToken = $G.__RequestVerificationToken;
            $.post(buildUrl('~/Setting/SetSysConfig'), filter, function (res) {
                vm.isPosting = false;
                if (res.error) {
                    Msg.alert(res.error.message);
                    return;
                }

                Msg.prompt('保存成功');
            });
        }
    },
    created: function () {
        this.get();
    }
});