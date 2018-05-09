var vm = new Vue({
    el: '#app',
    data: {
        keyword: null,
        pageIndex: 1,
        pageSize: 20,
        totalCount: 0,
        tableData: [],
        dialogFormVisible: false,
        formLabelWidth: '100px',
        form: {
            rowIndex:null,
            Id:null,
            Name: '',
            Sex: '男',
            CardNo: '',
            Phone: '',
            WxChat: '',
            Address: '',
            Remark: '',
            BankName: '',
            BankDeposit: '',
            BankAccount:''
        },
        imageUrl: ''
    },
    computed: {
        dialogTitle: function () {
            return this.form.Id==null ? '新增业主' : '修改业主';
        }
    },
    methods: {
        getList: function () { },
        search:function(){},
        openAdd: function () {
            this.dialogFormVisible = true;
        },
        openDetail: function () { },
        editUser: function () { },
        deleteUser: function () { },
        flipPage: function () { },
        close: function () { },
        addOwner: function () { },
        handleAvatarSuccess: function () { },
        beforeAvatarUpload: function () { }
    },
    created: function () {
        this.getList();
    }
});