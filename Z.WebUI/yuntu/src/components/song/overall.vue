<style lang="less" scoped>
	body{
		background-color: #efefef;
	}
	.section{
		.aside{
			display: inline-block;
		}
		.panel{
            .outer{
                background-color: #efefef;
                overflow: hidden;
                min-height: 400px;  
            }
            .form{
                width: 630px;
                margin: 80px auto 0;
                .tab{
                    display: inline-block;
                    width: 100px;
                    text-align: right;
                }
                .s{
                    margin: 8px 0;
                    .short{
                        width: 94px;
                    }
                    .medium{
                        width: 187px;
                    }
                    .long{
                        width: 200px;
                    }
					.co_red{
						margin-left: 5px;
						position: relative;
						top: 2px;
					}
					.tip{
						font-size: 12px;
						color: #999;
					}
                }
                .btn{
                    margin-top: 30px;  
					padding-left: 170px;
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
						<router-link :to="{path:'/overall'}" class="sub" style="display:block;">系统设置</router-link>
					</el-menu-item>
					<el-menu-item index="2">
						<router-link :to="{path:'/index'}" class="sub" style="display:block;">工作台</router-link>
					</el-menu-item>
				</el-menu> 
			</div>
			<div class="container">
				<div class="aside">
					<el-menu default-active="1" class="el-menu-vertical-demo">
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
                    <div class="outer">
                        <div class="form">
                            <div class="s">
                                <span class="tab">分成比例：</span>
                                <el-input v-model="configData.divideRate" size="mini" class="long"></el-input></el-input>
                                <b class="co_red">*</b>
								<span class="tip">设置平台与业主分成比例，如4表示业主4成</span>
                            </div>
                            <div class="s">
                                <span class="tab">固定损耗：</span>
                                <el-input v-model="configData.lossFee" size="mini" class="long"></el-input>
                                <b class="co_red">*</b>
								<span class="tip">设置客房固定损耗金额</span>
                            </div>
                            <div class="s">
                                <span class="tab">平台扣点：</span>
                                <el-input v-model="configData.platformRate" size="mini" class="medium"></el-input>%
                                <b class="co_red">*</b>
								<span class="tip">设置设置第三方平台扣款比例</span>
                            </div>
                            <div class="s">
                                <span class="tab">客房海报数量：</span>
                                <el-input v-model="configData.roomImageNum" size="mini" class="long"></el-input>
                                <b class="co_red">*</b>
								<span class="tip">设置房间能上传海报图片最大数量</span>
                            </div>
                            <div class="s">
                                <span class="tab">业主保底分成：</span>
                                <el-input v-model="configData.userFee" size="mini" class="long"></el-input>
                                <b class="co_red">*</b>
                            </div>
                            <div class="btn">
                                <el-button size="medium" type="warning" @click="saveConfig">保存</el-button>
                            </div>
                        </div>
                    </div>
                </div>
			</div>
		 </div>
	</div>
</template>
<script>
	import headerNav from '../header.vue'
	export default {
		data(){
            return {
                userInfo: '',
                configData: {
                    divideRate: 0,
                    lossFee: 0,
                    platformRate: 0,
                    roomImageNum: 6,
                    userFee: 0
                }
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
			async getList(key){
				let info = await http.get({
					url:'config',
					data:{
						
					}
				})
                if(info&&info.code==4000&&info.data){
                    this.configData.divideRate = info.data.divide_rate;
                    this.configData.lossFee = info.data.loss_fee;
                    this.configData.platformRate = info.data.platform_rate;
                    this.configData.roomImageNum = info.data.room_image_limit_num;
                    this.configData.userFee = info.data.user_min_fee;
                }
			},
            async saveConfig(){    
                let save = await http.post({
					url:'config',
					data:{
						divide_rate: this.configData.divideRate,
                        platform_rate: this.configData.platformRate,
                        loss_fee: this.configData.lossFee,
                        room_image_limit_num: this.configData.roomImageNum,
                        user_min_fee: this.configData.userFee
					}
				});
				if(save&&save.code===4000){
					Msg.prompt('修改成功');
				}
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