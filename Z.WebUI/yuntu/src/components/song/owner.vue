<style lang="less" scoped>
	body{
		background-color: #efefef;
	}
	.section{
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
                .el-form-item{
                    margin-bottom: 0;
                }
                .w{
                    position: relative;
                    .co_red{
                        position: absolute;
                        top: 0;
                        right: -8px;
                    }
                    .avator{
                        width: 120px;
                        height: 120px;
                    }
                }
            }
		}
	}
    .detail{
        .d{
            margin: 3px 0;
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
						<router-link :to="{path:'/owner'}" class="sub" style="display:block;">系统设置</router-link>
					</el-menu-item>
					<el-menu-item index="2">
						<router-link :to="{path:'/index'}" class="sub" style="display:block;">工作台</router-link>
					</el-menu-item>
				</el-menu> 
			</div>
			<div class="container">
				<div class="aside">
					<el-menu default-active="4" class="el-menu-vertical-demo">
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
                            关键字：<el-input size="mini" v-model="keyWord" placeholder="请输入内容"></el-input><el-button size="mini" type="primary" @click="getList">搜索</el-button>
                        </div>
                        <el-button class="btn" size="mini" type="warning" @click="openAdd">新增</el-button>
                    </div>
                    <div class="table">
                        <el-table :data="tableData" style="width: 100%">
                            <el-table-column prop="name" label="姓名"></el-table-column>
                            <el-table-column prop="sex" label="性别"></el-table-column>
                            <el-table-column prop="phone" label="电话"></el-table-column>
                            <el-table-column prop="room_num" label="客房数量"></el-table-column>
                            <el-table-column prop="created_name" label="创建人"></el-table-column>
                            <el-table-column prop="created_at" label="创建时间" width="160"></el-table-column>
                            <el-table-column width="120" label="操作" fixed="right">
                                <template slot-scope="scope">
                                    <el-popover v-model="scope.row.isShowDetail" placement="left" ref="popover2" trigger="click">
										<div class="detail">
                                            <div class="d"><span class="t">姓名：</span><span>{{scope.row.name}}</span></div>
                                            <div class="d"><span class="t">身份证：</span><span>{{scope.row.id_card}}</span></div>
											<div class="d"><span class="t">银行名称：</span><span>{{scope.row.bank_name}}</span></div>
                                            <div class="d"><span class="t">开户行：</span><span>{{scope.row.bank_deposit}}</span></div>
                                            <div class="d"><span class="t">银行账户：</span><span>{{scope.row.bank_account}}</span></div>
                                            <div class="d"><span class="t">地址：</span><span>{{scope.row.address}}</span></div>
                                            <div class="d"><span class="t">备注：</span><span>{{scope.row.remark}}</span></div>
                                            <div class="d"><span class="t">微信：</span><span>{{scope.row.wxchat}}</span></div>
										</div>
									</el-popover>
                                    <i class="el-icon-search icon" @click='openDetail(scope.row)' v-popover:popover2></i>
                                    <i class="el-icon-edit icon" @click="editUser(scope.row)"></i>
                                    <i class="el-icon-delete icon" @click="deleteUser(scope.row)"></i>
                                </template>
                            </el-table-column>
                        </el-table>
                    </div>
                    <div class="pagin">
                        <el-pagination background layout="prev, pager, next" :total="totalCount" :page-size="pageSize" @current-change="flipPage"></el-pagination>
                    </div>
                    <el-dialog title="提示" :visible.sync="dialogVisible" width="25%">
                        <span>确定要删除{{currentUser}}的信息吗？</span>
                        <span slot="footer" class="dialog-footer">
                            <el-button size="mini" @click="closeDelete">取 消</el-button>
                            <el-button size="mini" type="primary" @click="qrDelete">确 定</el-button>
                        </span>
                    </el-dialog>
                    <div class="add_panel">
                        <el-dialog title="新增业主信息" :visible.sync="dialogFormVisible">
                            <el-form :model="form" >
                                <el-row>
                                    <el-col :span="12">
                                        <el-form-item label="姓名：" :label-width="formLabelWidth" class="w">
                                            <el-input v-model="form.name" auto-complete="off" size="mini"></el-input>
                                            <span class="co_red">*</span>
                                        </el-form-item>
                                        <el-form-item label="性别：" :label-width="formLabelWidth" size="mini" style="margin: 2px 0;" class="w">
                                            <el-select v-model="form.sex">
                                                <el-option label="男" value="男"></el-option>
                                                <el-option label="女" value="女"></el-option>
                                            </el-select>
                                            <span class="co_red">*</span>
                                        </el-form-item>
                                        <el-form-item label="身份证号：" :label-width="formLabelWidth" class="w">
                                            <el-input v-model="form.idCard" auto-complete="off" size="mini"></el-input>
                                            <span class="co_red">*</span>
                                        </el-form-item>
                                        <el-form-item label="手机号码：" :label-width="formLabelWidth" class="w">
                                            <el-input v-model="form.phone" auto-complete="off" size="mini"></el-input>
                                            <span class="co_red">*</span>
                                        </el-form-item>
                                        <el-form-item label="微信号：" :label-width="formLabelWidth">
                                            <el-input v-model="form.wechart" auto-complete="off" size="mini"></el-input>
                                        </el-form-item>
                                        <el-form-item label="联系地址：" :label-width="formLabelWidth" style="margin: 5px 0 10px" class="w">
                                            <el-input type="textarea" :rows="2" v-model="form.address"></el-input>
                                            <span class="co_red">*</span>
                                        </el-form-item>
                                        <el-form-item label="备注：" :label-width="formLabelWidth">
                                            <el-input type="textarea" :rows="2" v-model="form.remark"></el-input>
                                        </el-form-item>
                                    </el-col>
                                    <el-col :span="12">
                                        <el-form-item label="头像：" :label-width="formLabelWidth" class="w">
                                            <el-upload class="avatar-uploader" action="http://39.108.139.149/back/upload" :headers="{token:userInfo?userInfo.token:null}" :show-file-list="false" :on-success="handleAvatarSuccess" :before-upload="beforeAvatarUpload">
                                                <img v-if="imageUrl" :src="imageUrl" class="avatar">
                                                <i v-else class="el-icon-plus avatar-uploader-icon"></i>
                                            </el-upload>
                                        </el-form-item>
                                        <el-form-item label="银行名称：" :label-width="formLabelWidth" class="w">
                                            <el-input v-model="form.bankName" auto-complete="off" size="mini"></el-input>
                                            <span class="co_red">*</span>
                                        </el-form-item>
                                        <el-form-item label="开户行：" :label-width="formLabelWidth" class="w">
                                            <el-input v-model="form.bankDeposit" auto-complete="off" size="mini"></el-input>
                                            <span class="co_red">*</span>
                                        </el-form-item>
                                        <el-form-item label="银行卡号：" :label-width="formLabelWidth" class="w">
                                            <el-input v-model="form.bankAccount" auto-complete="off" size="mini"></el-input>
                                            <span class="co_red">*</span>
                                        </el-form-item>
                                    </el-col>
                                </el-row>
                            </el-form>
                            <div slot="footer" class="dialog-footer">
                                <el-button size="mini" @click="close">取 消</el-button>
                                <el-button size="mini" type="primary" @click="addOwner">确 定</el-button>
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
				tableData: [],
                dialogFormVisible: false,
                form: {
                    name: '',
                    sex: '男',
                    idCard: '',
                    phone: '',
                    wechart: '',
                    address: '',
                    remark: '',
                    bankName: '',
                    bankDeposit: '',
                    bankAccount: ''
                },
                formLabelWidth: '100px',
                keyWord: '',
                currentId: null,
                dialogVisible: false,
                currentUser: '',
                currentPage: 1,
				totalCount: 1,
                pageSize: 15,
                imageUrl: '',
                userInfo:null,
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
                let userData = {
					per_page: this.pageSize,
                    page: this.currentPage
                }
                if(this.keyWord){
                    userData.key = this.keyWord;
                }
				let userInfo = await http.get({
					url: 'user',
					data: userData
				});
				if(userInfo&&userInfo.code===4000&&userInfo.data){
                    this.$set(this, 'totalCount', userInfo.data.total);
                    this.tableData = userInfo.data.data;
                    var that = this;
					this.tableData.map(function(item, index){
						that.$set(item, 'isShowDetail', false);
					})
                }
			},
            openAdd(){
                this.form.name = '';
                this.form.sex = '男';
                this.form.idCard = '';
                this.form.phone = '';
                this.form.wechart = '';
                this.form.address = '';
                this.form.remark = '';
                this.form.bankName = '';
                this.form.bankDeposit = '';
                this.form.bankAccount = '';
                this.imageUrl = '';
                this.dialogFormVisible = true;
            },
            async addOwner(){
                var that = this;
                if(!this.form.name){
					Msg.prompt('请输入姓名');
					return;
				}
                if(!this.form.idCard){
					Msg.prompt('请输入身份证号');
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
                if(!this.form.address){
					Msg.prompt('请输入地址');
					return;
				}
                if(!this.form.bankName){
					Msg.prompt('请输入银行名称');
					return;
				}
                if(!this.form.bankDeposit){
					Msg.prompt('请输入开户行');
					return;
				}
                if(!this.form.bankAccount){
					Msg.prompt('请输入银行账户');
					return;
				}
                let userForm = {
                    name: this.form.name,
                    sex: this.form.sex,
                    id_card: this.form.idCard,
                    phone: this.form.phone,
                    address: this.form.address,
                    bank_name: this.form.bankName,
                    bank_deposit: this.form.bankDeposit,
                    bank_account: this.form.bankAccount
                }
                if(this.imageUrl){
                    userForm.img = this.imageUrl;
                }
                if(this.form.wechart){
                    userForm.wxchat = this.form.wechart;
                };
                if(this.form.remark){
                    userForm.remark = this.form.remark;
                };
                if(this.currentId){
                    userForm.id = this.currentId;
                };
                let add = await http.post({
                    url: 'user',
                    data: userForm
                });
                if(add.code===4000){
                    this.getList();
                    this.close();
                }
            },
            editUser(row){
                this.dialogFormVisible = true;
                this.form.name = row.name;
                this.form.sex = row.sex;
                this.form.idCard = row.id_card;
                this.form.phone = row.phone;
                this.form.wechart = row.wxchat;
                this.form.address = row.address;
                this.form.remark = row.remark;
                this.form.bankName = row.bank_name;
                this.form.bankDeposit = row.bank_deposit;
                this.form.bankAccount = row.bank_account;
                this.imageUrl = row.img;
                this.currentId = row.id;
            },
            close(){
                this.dialogFormVisible = false;
                this.currentId = null;
            },
            deleteUser(row){
                this.currentUser = row.name;
                this.currentId = row.id;
                this.dialogVisible=true;
            },
            closeDelete(){
                this.currentUser = '';
                this.currentId = null;
                this.dialogVisible = false;
            },
            async qrDelete(){
                let del = await http.delete({
                    url: 'user/'+this.currentId,
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
            handleAvatarSuccess(res, file) {
                this.imageUrl = URL.createObjectURL(file.raw);
            },
            beforeAvatarUpload(file) {
                const isJPG = file.type === 'image/jpeg';
                const isLt2M = file.size / 1024 / 1024 < 2;

                if (!isJPG) {
                    this.$message.error('上传头像图片只能是 JPG 格式!');
                }
                if (!isLt2M) {
                    this.$message.error('上传头像图片大小不能超过 2MB!');
                }
                return isJPG && isLt2M;
            },
            openDetail(row){
				row.isShowDetail = true;
			},
		},
		created(){
			this.getList();
            this.userInfo=JSON.parse(sessionStorage.getItem('userInfo'));
		},
		mounted(){
			
        }
	}
</script>