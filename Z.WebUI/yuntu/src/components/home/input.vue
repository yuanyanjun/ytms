<style lang="less" scoped>
	body{
		background-color: #efefef;
	}
	.section{
		.container:after{
			content: '';
			display: black;
			clear: both;
		}
		.aside{
			float: left;
			.sub{
				color: #666;
          		display: block;
			}
			.is-active{
				.sub{
					color: #409eff;
				}
			}
		}
		.panel{
			background-color: #efefef;
			padding: 10px 20px;
			margin-right: 10px;
			.el-input{
				width: 200px;
			}
			.panel_inner{
				margin: 10px;
				padding: 5px 0;
				overflow-y: auto;
				position: absolute;
				top: 40px;
				left: 0;
				right: 0;
				bottom: 70px;
				.panel_inner:after{
					content: '';
					display: block;
					clear: both;
				}
				.item{
					float: left;
					width: 280px;
					background-color: #909399;
					color: #fff;
					padding: 10px 20px;
					border-radius: 5px;	
					position: relative;
					margin: 5px;
					.home{
						position: absolute;
						right: 10px;
						top: 10px;
						font-size: 18px;
						cursor: pointer;
					}
					.name{
						margin: 10px 0;
						font-size: 16px;
					}
					.n{
						margin: 4px 0;
						font-size: 12px;
						.tab{
							display: inline-block;
							width: 60px;
							text-align: right;
						}
					}
					.btn_box{
						text-align: center;
						.el{
							font-size: 24px;
							margin: 8px;
							cursor: pointer;
						}
					}
				}
				.item.green{
					background-color: #67c23a;
				}
			}
			.pagin{
				text-align: center;
			}
		}
		.user_check{
			display: inline-block;
			position: relative;
			.user_panel{
				background-color: #fff;
				box-shadow: 0 1px 3px #999;
				width: 200px;
				min-height: 50px;
				position: absolute;
				top: 32px;
				left: 0;
				z-index: 100;
				font-size: 12px;
				.p{
					padding: 5px 15px;
					cursor: pointer;
				}
				.p:hover{
					background-color: #ecf5ff;
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
				<el-menu default-active="2" class="el-menu-demo" mode="horizontal">
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
					<el-menu default-active="4" class="el-menu-vertical-demo">
						<el-menu-item index="1">
							<router-link :to="{path:'/multiplecheck'}" class="sub">
								<i class="el-icon-menu"></i>
								<span>预定</span>
							</router-link>
						</el-menu-item>
						<!--<el-menu-item index="2">
							<router-link :to="{path:'/checkin'}" class="sub">
								<i class="el-icon-document"></i>
								<span>入住</span>
							</router-link>
						</el-menu-item>
						<el-menu-item index="3">
							<router-link :to="{path:'/checkout'}" class="sub">
								<i class="el-icon-goods"></i>
								<span>结账退房</span>
							</router-link>
						</el-menu-item>-->
						<el-menu-item index="4">
							<router-link :to="{path:'/input'}" class="sub">
								<i class="el-icon-edit-outline"></i>
								<span>水电气录入</span>
							</router-link>
						</el-menu-item>
						<el-menu-item index="5">
							<router-link :to="{path:'/settlement'}" class="sub">
								<i class="el-icon-tickets"></i>
								<span>月结账</span>
							</router-link>
						</el-menu-item>
					</el-menu>
				</div>
				<div class="panel">
					<div class="input_box">
						关键字：<el-input v-model.lazy="keyWord" size="small" placeholder="请输入内容" style="margin-right:20px;"></el-input>
						业主：
						<div class="user_check">
							<el-input v-model.lazy="userName" @focus="close=false" size="small" placeholder="请输入内容" style="margin-right:20px;"></el-input>
							<div class="user_panel" v-show="isShowUser">
								<div class="p" v-for="item in ownerInfo" @click="chooseUser(item)">{{item.name}}</div>
							</div>
						</div>
						录入月份：<el-date-picker size="small" v-model="date" value-format="yyyy-MM" type="month" placeholder="选择日期" @change="getList"></el-date-picker>
					</div>
					<div class="panel_inner">
						<div class="item" :class="{green:item.hasData}" v-for="(item,index) in listDataCopy">
							<div class="name">{{item.room_no}}</div>
							<div class="n">
								<span class="tab">录入月份：</span><span>{{item.public_fee_single.updated_at}}</span>
							</div>
							<div class="n">
								<span class="tab">物业费：</span><el-input size="mini" v-model="item.public_fee_single.property_fee"></el-input>
							</div>
							<div class="n">
								<span class="tab">水费：</span><el-input size="mini" v-model="item.public_fee_single.water_fee"></el-input>
							</div>
							<div class="n">	
								<span class="tab">电费：</span><el-input size="mini" v-model="item.public_fee_single.electricity_fee"></el-input>
							</div>
							<div class="n">
								<span class="tab">燃气费：</span><el-input size="mini" v-model="item.public_fee_single.gas_fee"></el-input>
							</div>
							<div class="btn_box">
								<b class="el-icon-check el" @click="eidt(item)"></b>
								<b class="el-icon-close el" @click="delRecord(item)"></b>
							</div>
						</div>
					</div>
					<div class="pagin">
						<el-pagination background layout="prev, pager, next" :total="totalPage" @current-change="flipPage"></el-pagination>
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
				per_page:20,
                currentPage:1,
				totalPage: 1,
				listData: [],
				listDataCopy: [],
				date: this.formatDate(),
				keyWord: '',
				userName: '',
				isShowUser: false,
				ownerInfo: [],
				close: false
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
		watch: {
			keyWord(newVal, oldVal){
				this.getList();
			},
			async userName(newVal, oldVal){
				let ownerInfo = await http.get({
					url: 'user',
					data: {
                        key: newVal
					}
				});
				if(ownerInfo&&ownerInfo.code===4000&&ownerInfo.data){
                    this.ownerInfo = ownerInfo.data.data;
					if(!this.close){
						this.isShowUser = true;
					}
                }
			}
		},
		methods:{
			async getList(){
				let requestData = {
					per_page: this.per_page
				}
				if(this.date){
					requestData.date_time = this.date;
				}
				if(this.keyWord){
					requestData.key = this.keyWord;
				}
				if(this.userName){
					requestData.user = this.userName;
				}
				let list = await http.get({
					url: 'public-fee',
					data: requestData
				})
				if(list.code===4000&&list.data&&list.data.data){
					this.listData = list.data.data;
					this.totalPage = list.data.last_page;
					var that = this;
					this.listData.map(function(item,index){
						that.$set(item,'hasData',true);
						if(!item.public_fee_single){
							var tempObj = {
								property_fee: item.property_fee,
								water_fee: '',
								electricity_fee: '',
								gas_fee: ''
							};
							that.$set(item,'public_fee_single',tempObj);
							item.hasData = false;
						}else{
							item.public_fee_single.updated_at = item.public_fee_single.updated_at.substring(0,7);
						}
					});
					this.listDataCopy = JSON.parse(JSON.stringify(this.listData));
				}
			},
			flipPage(page){
				this.currentPage = page;
				this.getList();
			},
			async eidt(row){
				let reqeustData = {
					room_id: row.id,
					property_fee: row.public_fee_single.property_fee,
					water_fee: row.public_fee_single.water_fee,
					electricity_fee: row.public_fee_single.electricity_fee,
					gas_fee: row.public_fee_single.gas_fee,
					date_time: this.formatDate()
				}
				if(row.public_fee_single&&row.public_fee_single.id){
					reqeustData.id = row.public_fee_single.id;
				}
				let feeRequest = await http.post({
					url: 'public-fee',
					data: reqeustData
				})
				if(feeRequest.code===4000){
					this.getList();
				}
			},
			formatDate(){
                let time = new Date();
                let y = time.getFullYear();
                let m = time.getMonth() + 1;
				let d = time.getDate();
                return y+"-"+m+"-"+d;
            },
			chooseUser(res){
				this.userName = res.name;
				this.isShowUser = false;
				this.close = true;
				this.getList();
			},
			async delRecord(res){
				let del = await http.delete({
					url: 'public-fee/'+res.public_fee_single.id,
					data: {}
				})
				if(del.code===4000){
					this.getList();
					Msg.prompt('删除成功');
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