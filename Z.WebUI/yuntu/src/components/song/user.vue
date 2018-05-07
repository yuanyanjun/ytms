<style lang="less" scoped>
	body{
		background-color: #efefef;
	}
	.section{
		.aside{
			display: inline-block;
		}
		.panel{
			.head{
				margin: 15px 0;
				position: relative;
				.btn{
					position: absolute;
					top: 0;
					right: 0;
				}
				.el-input{
					width: 200px;
					margin-right: 5px;
				}
			}
			.table{
				position: absolute;
				top: 58px;
				bottom: 60px;
				left: 0;
				width: 100%;
				overflow: auto;
				.icon{
					margin-left: 3px;
					font-size: 18px;
					cursor: pointer;
				}
				.pagin{
					text-align: center;
					margin: 20px 0;	
				}
			}
			.add_panel{
				.el-input{
					width: 200px;
				}
				.el-form-item{
					margin-bottom: 0;
				}
				.el-dialog{
					text-align: center;
				}
			}
			.reset_panel{
				.el-input{
					width: 200px;
				}
				.el-form-item{
					margin-bottom: 0;
				}
				.el-dialog{
					text-align: center;
				}
			}
			.authority_panel{
				.d_body{
					width: 500px;
					margin: auto;
					.el-button{
						margin: 5px 10px;
					}
				}
			}
		}
	}
</style>
<template>
	<div>
		 <header-nav></header-nav>
		 <div class="section">
		 	<div style="margin-bottom:20px;">
				<el-menu default-active="1" class="el-menu-demo" mode="horizontal">
					<el-menu-item index="1">
						<router-link :to="{path:'/user'}" class="sub" style="display:block;">系统设置</router-link>
					</el-menu-item>
					<el-menu-item index="2">
						<router-link :to="{path:'/index'}" class="sub" style="display:block;">工作台</router-link>
					</el-menu-item>
				</el-menu> 
			</div>
			<div class="container">
				<div class="aside">
					<el-menu default-active="3" class="el-menu-vertical-demo">
						<el-menu-item index="1">
							<router-link :to="{path:'/overall'}" class="sub">
								<i class="el-icon-document"></i>
								<span>全局信息管理</span>
							</router-link>
						</el-menu-item>
						<el-menu-item index="2">
							<router-link :to="{path:'/room'}" class="sub">
								<i class="el-icon-document"></i>
								<span>房型项目管理</span>
							</router-link>
						</el-menu-item>
						<el-menu-item index="3">
							<router-link :to="{path:'/user'}" class="sub">
								<i class="el-icon-document"></i>
								<span>用户管理</span>
							</router-link>
						</el-menu-item>
						<el-menu-item index="4">
							<router-link :to="{path:'/owner'}" class="sub">
								<i class="el-icon-menu"></i>
								<span>业主信息管理</span>
							</router-link>
						</el-menu-item>
						<el-menu-item index="5">
							<router-link :to="{path:'/guestroom'}" class="sub">
								<i class="el-icon-menu"></i>
								<span>客房管理</span>
							</router-link>	
						</el-menu-item>
						<el-menu-item index="6">
							<router-link :to="{path:'/tagmanage'}" class="sub">
								<i class="el-icon-menu"></i>
								<span>标签管理</span>
							</router-link>	
						</el-menu-item>
					</el-menu>
				</div>
				<div class="panel">
                              <div class="head">
                                    <div class="search">
                                          关键字：<el-input v-model="keyWord" size="mini" placeholder="请输入内容"></el-input><el-button size="mini" type="primary" @click="getList">搜索</el-button>
                                    </div>
                                    <el-button class="btn" size="mini" type="warning" @click="addAdmin">新增</el-button>
                              </div>
                              <div class="table">
                                    <el-table :data="tableData" style="width: 100%">
                                          <el-table-column prop="name" label="姓名"></el-table-column>
                                          <el-table-column prop="sex" label="性别"></el-table-column>
                                          <el-table-column prop="phone" label="手机号码"></el-table-column>
                                          <el-table-column prop="account" label="登录账号"></el-table-column>
                                          <el-table-column prop="wxchat" label="微信号"></el-table-column>
                                          <el-table-column prop="type" label="账号类型"></el-table-column>
                                          <el-table-column prop="created_name" label="创建人"></el-table-column>
                                          <el-table-column width="160" prop="created_at" label="创建时间"></el-table-column>
                                          <el-table-column width="140" label="操作">
                                                <template slot-scope="scope">
                                                      <i class="el-icon-view icon" @click="editPwd(scope.row)"></i>
                                                      <!--<i class="el-icon-setting icon" @click="dialogAuthorityVisible=true"></i>-->
                                                      <i class="el-icon-edit icon" @click="editAdmin(scope.row)"></i>
                                                      <i class="el-icon-delete icon" @click="deleteAdmin(scope.row)"></i>
                                                </template>
                                          </el-table-column>
                                    </el-table>
                              </div>
							  <div class="pagin">
									<el-pagination background layout="prev, pager, next" :total="totalCount" :page-size="pageSize" @current-change="flipPage"></el-pagination>
							</div>
					<el-dialog title="提示" :visible.sync="dialogVisible" width="25%">
						<span>确定要删除{{currentAdmin}}的信息吗？</span>
						<span slot="footer" class="dialog-footer">
						<el-button size="mini" @click="closeDelete">取 消</el-button>
						<el-button size="mini" type="primary" @click="qrDelete">确 定</el-button>
						</span>
					</el-dialog>
					<div class="add_panel">
						<el-dialog title="新增用户" :visible.sync="dialogFormVisible">
							<el-form :model="form" style="display: block;margin: auto;">
								<el-form-item label="登录账号：" :label-width="formLabelWidth">
									<el-input v-model="form.account" minlength="1" auto-complete="off" size="mini"></el-input>
									<span class="co_red">*</span>
								</el-form-item>
								<el-form-item label="登录密码：" :label-width="formLabelWidth">
									<el-input v-model="form.password" minlength="1" type="password" auto-complete="off" size="mini"></el-input>
									<span class="co_red">*</span>
								</el-form-item>	
								<el-form-item label="重复密码：" :label-width="formLabelWidth">
									<el-input v-model="form.confirm" minlength="1" type="password" auto-complete="off" size="mini"></el-input>
									<span class="co_red">*</span>
								</el-form-item>
								<el-form-item label="真实姓名：" :label-width="formLabelWidth">
									<el-input v-model="form.name" minlength="1" auto-complete="off" size="mini"></el-input>
									<span class="co_red">*</span>
								</el-form-item>
								<el-form-item label="性别：" :label-width="formLabelWidth">
									<el-select v-model="form.sex" size="mini">
										<el-option label="男" value="male"></el-option>
										<el-option label="女" value="famale"></el-option>
									</el-select>
									<span class="co_red">*</span>
								</el-form-item>
								<el-form-item label="手机号码：" :label-width="formLabelWidth">
									<el-input v-model="form.phone" auto-complete="off" size="mini"></el-input>
									<span class="co_red">*</span>
								</el-form-item>
								<el-form-item label="微信号：" :label-width="formLabelWidth">
									<el-input v-model="form.wxchat" minlength="1" auto-complete="off" size="mini"></el-input>
								</el-form-item>
							</el-form>	
							<div slot="footer" class="dialog-footer">
								<el-button size="mini" @click="closeAdd">取 消</el-button>
								<el-button size="mini" type="primary" @click="qrAdd">确 定</el-button>
							</div>
						</el-dialog>
					</div>
					<div class="reset_panel">
						<el-dialog title="重置密码" :visible.sync="dialogResetVisible">
							<el-form :model="form" style="display: block;margin: auto;">
								<el-form-item label="登录账号：" :label-width="formLabelWidth">
									<b>{{currentAccount}}</b>
								</el-form-item>
								<el-form-item label="新密码：" :label-width="formLabelWidth">
									<el-input v-model="form2.pwd" auto-complete="off" size="mini"></el-input>
									<span class="co_red">*</span>
								</el-form-item>	
								<el-form-item label="确认密码：" :label-width="formLabelWidth">
									<el-input v-model="form2.repwd" auto-complete="off" size="mini"></el-input>
									<span class="co_red">*</span>
								</el-form-item>
							</el-form>
							<div slot="footer" class="dialog-footer">
								<el-button @click="closeEditPwd">取 消</el-button>
								<el-button type="primary" @click="qrEditPwd">确 定</el-button>
							</div>
						</el-dialog>
					</div>
					<div class="authority_panel">
						<el-dialog title="权限设置" :visible.sync="dialogAuthorityVisible">
							<div class="d_body">
								<el-button type="primary" plain>新增预定</el-button>
								<el-button type="primary" plain>散客步入</el-button>
								<el-button type="primary" plain>宾客列表</el-button>
								<el-button type="primary" plain>实时房态</el-button>
								<el-button plain>报表中心</el-button>
								<el-button plain>系统设置</el-button>
							</div>
							<div slot="footer" class="dialog-footer">
								<el-button @click="dialogAuthorityVisible = false">取 消</el-button>
								<el-button type="primary" @click="dialogAuthorityVisible = false">确 定</el-button>
							</div>
						</el-dialog>
					</div>
                        </div>
			</div>
		 </div>
	</div>
</template>
<script>
	import axios from 'axios'
	import config from '../../config'
	import headerNav from '../header.vue'
	export default {
		data(){
            	return {
				userInfo: '',
				tableData: [],
				dialogFormVisible: false,
				form: {
					account: '',
					password: '',
					confirm: '',
					name: '',	
					sex: '男',
					phone: '',
					wxchat: '',
					type: []
				},
				dialogResetVisible: false,
				form2: {
					pwd: '',
					repwd: ''	
				},
				dialogAuthorityVisible: false,
				formLabelWidth: '120px',
				keyWord: '',
				currentId: null,
				currentAdmin: '',
				currentAccount: '',
				dialogVisible: false,
				currentPage: 1,
				totalCount: 1,
				pageSize: 15
			}				
		},
		components: {headerNav},
		computed: {
			nowTime(){
				let time = new Date();
				let y = time.getFullYear();
				let m = time.getMonth() + 1;
			let d = time.getDate();
				return y+"-"+m+"-"+d;
			}
		},
		methods:{
			async getList(){
				let adminData = {
					per_page: this.pageSize,
					page: this.currentPage
				};
				if(this.keyWord){
					adminData.key = this.keyWord;
				}
				let userInfo = await http.get({
					url: 'admin',
					data: adminData
				});
				if(userInfo&&userInfo.code===4000&&userInfo.data){
					this.$set(this, 'totalCount', userInfo.data.total);
					this.tableData = userInfo.data.data;
				}
			},
			addAdmin(){
				this.form.account = '';
				this.form.password = '';
				this.form.confirm = '';
				this.form.name = '';
				this.form.sex = '男';
				this.form.phone = '';
				this.form.wxchat = '';
				this.form.type = '';
				this.dialogFormVisible = true;
			},
			async qrAdd(){
				var that = this;
				if(!this.form.account){
					Msg.prompt('请输入账户');
					return;
				}
				if(!this.form.name){
					Msg.prompt('请输入姓名');
					return;
				}
				if(!this.form.phone){
					Msg.prompt('请输入电话号码');
					return;
				}
				var phoneReg=/^[1][3,4,5,7,8][0-9]{9}$/;
				if(!phoneReg.test(that.form.phone)){
					Msg.prompt('请输入有效电话号码');
				}
				
				let addData = {
					account: this.form.account,
					password: this.form.password,
					password_confirmation: this.form.confirm,
					name: this.form.name,
					sex: this.form.sex,
					phone: this.form.phone
				};
				if(this.form.wxchat){
					addData.wxchat = this.form.wxchat;
				}
				if(this.form.type){
					addData.type = this.form.type;
				}
				if(this.currentId){
					addData.id = this.currentId;
				}
				let add = await http.post({
					url: 'admin',
					data: addData
				});
				if(add.code===4000){
					this.getList();
					this.closeAdd();
				}
			},
			closeAdd(){
				this.dialogFormVisible = false;
				this.currentId = null;
			},
			editAdmin(row){
				this.form.account = row.account;
				this.form.name = row.name;
				this.form.sex = row.sex;
				this.form.phone = row.phone;
				this.form.wxchat = row.wxchat;
				this.form.type = row.type;
				this.currentId = row.id;
				this.dialogFormVisible = true;
			},
			deleteAdmin(row){
				this.currentAdmin = row.name;
				this.currentId = row.id;
				this.dialogVisible = true;
			},
			closeDelete(){
				this.currentAdmin = '';
				this.currentId = null;
				this.dialogVisible = false;
			},
			async qrDelete(){
				let del = await http.delete({
					url: 'admin/'+this.currentId,
					data: {

					}
				});
				if(del.code===4000){
					this.getList();
					this.closeDelete();
				}
			},
			flipPage(page){
				this.currentPage = page;
				this.getList();
			},
			editPwd(res){
				this.currentAccount = res.account;
				this.dialogResetVisible=true;
			},
			closeEditPwd(){
				this.form2.pwd = '';
				this.form2.repwd = '';
				this.currentAccount = '';
				this.dialogResetVisible = false;
			},
			async qrEditPwd(){
				if(!this.form2.pwd){
					Msg.alert('请输入新密码');
					return;
				}
				if(!this.form2.repwd){
					Msg.alert('请重复新密码');
					return;
				}
				if(this.form2.pwd!==this.form2.repwd){
					Msg.alert('密码不一致');
					return;
				}
				let edit = await http.post({
					url: 'user-info',
					data: {
						account: this.currentAccount,
						password: this.form2.pwd,
						password_confirmation: this.form2.repwd
					}
				})
				if(edit&&edit.code===4000){
					Msg.prompt('修改成功');
				}
				this.closeEditPwd();
			}
		},
		created(){
			this.getList();
			this.userInfo = JSON.parse(sessionStorage.getItem('userInfo')).record;
		},
		mounted(){
			
        }
	}
</script>

