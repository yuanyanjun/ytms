<style lang="less" scoped>
	.el-input{
        width: 260px;
    }
    .el-button{
        width: 260px;
    }
    .login_box{
        position: absolute;
        top: 0;
        left: 0;
        right: 0;
        bottom: 0;
        margin: auto;
        width: 350px;
        height: 300px;
        .tit{
            font-size: 30px;
            text-align: center;
            margin-bottom: 20px;
        }
    }
</style>
<template>
	<div class="login_box">
        <div class="tit">云途城市民宿</div>
		<el-form :model="ruleForm2" status-icon :rules="rules2" ref="ruleForm2" label-width="50px" class="demo-ruleForm">
            <el-form-item label="账号" prop="account">
                <el-input v-model.number="ruleForm2.account"></el-input>
            </el-form-item>
            <el-form-item label="密码" prop="pass">
                <el-input type="password" v-model="ruleForm2.pass" auto-complete="off"></el-input>
            </el-form-item>
            <el-form-item>
                <el-button type="primary" @click="submitForm('ruleForm2')">提交</el-button>
            </el-form-item>
        </el-form>   
	</div>
</template>
<script>
	
	export default {
		data(){
            var validatePass = (rule, value, callback) => {
                if (value === '') {
                    callback(new Error('请输入密码'));
                } else {
                    callback();
                }
            };
            return {
                ruleForm2: {
                    pass: '',
                    account: ''
                },
                rules2: {
                    pass: [
                        { validator: validatePass, trigger: 'blur' }
                    ]
                }
            };			
		},
		methods:{
            async login(key){
                let userInfo=await http.post({
                    url:'login',
                    data:{
                        account:this.ruleForm2.account,
                        password:this.ruleForm2.pass
                    }
                })
                if(userInfo&&userInfo.code===4000&&userInfo.data){
                    sessionStorage.setItem('userInfo',JSON.stringify(userInfo.data));
                    this.$router.push({path:'/index'})
                }
            },
			submitForm(formName) {
                this.$refs[formName].validate((valid) => {
                    if (valid) {
                        this.login();
                    } else {
                        console.log('error submit!!');
                        return false;
                    }
                });
            }
		},
		created(){
			
		},
		mounted(){
			
        }
	}
</script>