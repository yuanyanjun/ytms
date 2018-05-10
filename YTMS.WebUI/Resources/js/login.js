var vm = new Vue({
    el: '#app',
    data: {
        postStatus: 0,
        form: {
            Account: '',
            Password: ''
        }
    },
    methods: {
        submitForm: function () {

            if (this.postStatus>0)
            {
                Msg.prompt('您手速太快，请稍后...');
                return;
            }

            this.postStatus = 1;
            var filter = this.form;

            if (!filter.Account)
            {
                Msg.prompt('账号不能为空');
                return;
            }

            if (!filter.Password) {
                Msg.prompt('密码不能为空');
                return;
            }

            filter.__RequestVerificationToken = $G.__RequestVerificationToken;
            $.post(buildUrl('~/Login/SignIn'), filter, function (res) {
                if (res.error) {
                    Msg.prompt(res.error.message);
                    vm.postStatus = 0;
                    return;
                }

                vm.postStatus = 2;

                window.location.href = buildUrl('~/home/index');
            });
        }
    },
    computed:{
        btnText: function () {
            if (this.postStatus = 0) {
                return '登录';
            }
            else if (this.postStatus == 1) {
                return '登录...';
            }
            else if (this.postStatus == 2) {
                return '跳转中...';
            }

            return '登录';
        }
    },
    created: function () {

    }
});