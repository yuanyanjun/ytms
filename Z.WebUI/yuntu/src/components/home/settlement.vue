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
			.el-input{
				width: 200px;
			}
            .input_box{
                position: relative;
                .el-button{
                    position: absolute;
                    top: 5px;
                    right: 20px;
                }
            }
			.pagin{
				text-align: center;
			}
            .part_two{
				background-color: #fff;
				position: absolute;
				top: 50px;
				left: 20px;
				right: 20px;
				bottom: 304px;
				overflow-y: auto;
            }
            .detail{	
                background-color: #fff;
				position: absolute;
				left: 20px;
				right: 20px;
				bottom: 220px;
                .title{
                    border-bottom: 1px solid #ddd;
                    padding: 5px 10px;
                }
                .inner{
                    padding: 10px 10px;
                }
				.inner2{
                    padding: 10px 10px;
					text-align: center;
					color: #909399;
                }
            }
			.detail_list{
				position: absolute;
				bottom: 10px;
				left: 20px;
				right: 20px;
				height: 200px;
				background-color: #fff;
				overflow-y: auto;
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
					<el-menu default-active="5" class="el-menu-vertical-demo">
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
						结算月份：<el-date-picker size="small" v-model="date" value-format="yyyy-MM" type="month" placeholder="选择日期" @change="getList"></el-date-picker>
						<!--<el-button size="mini" type="warning" @click="settlement">结算</el-button>-->
					</div>
					<div class="part_two">
						<el-table ref="multipleTable" :data="tableData" style="width: 100%" @current-change="getDetail">
							<el-table-column prop="room_no" label="房间编号"></el-table-column>
							<el-table-column prop="user.name" label="业主"></el-table-column>
							<el-table-column prop="total_money" label="总收入"></el-table-column>
							<el-table-column prop="real_money" label="纯利润"></el-table-column>
							<el-table-column prop="user_money" label="业主收入"></el-table-column>
							<el-table-column prop="finished_at" label="结算日期"></el-table-column>
							<el-table-column label="操作">
								<template slot-scope="scope">
									<span v-if="scope.row.finished_at" class="co_green">已结算</span>
									<el-button v-else type="warning" size="mini" @click.stop="settlement(scope.row)">结算</el-button>
								</template>
							</el-table-column>
						</el-table>
					</div>
					<div class="detail">
						<div class="title co_green">结算详情</div>
						<div class="inner2" v-show="!isShowDetail">暂无数据</div>
						<div class="inner" v-show="isShowDetail">
							<div style="margin-bottom:5px;">
								总营业额：<span class="co_red" style="margin-right:20px;">{{detailInfo.total_money}}</span>
								实际收入：<span class="co_red" style="margin-right:20px;">{{detailInfo.real_money}}</span>
								物业费：<span class="co_red" style="margin-right:20px;">{{detailInfo.property_fee}}</span>
								水费：<span class="co_red" style="margin-right:20px;">{{detailInfo.water_fee}}</span>
								电费：<span class="co_red" style="margin-right:20px;">{{detailInfo.electricity_fee}}</span>
								燃气费：<span class="co_red" style="margin-right:20px;">{{detailInfo.gas_fee}}</span>
								平台扣点：<span class="co_red" style="margin-right:20px;">{{detailInfo.platform_fee}}</span>
								固定损耗：<span class="co_red" style="margin-right:20px;">{{detailInfo.loss_fee}}</span>
							</div>
						</div>
					</div>
					<div class="detail_list">
						<el-table :data="tableData2" style="width: 100%">
							<el-table-column prop="day_time" label="日期"></el-table-column>
							<el-table-column prop="base_fee" label="基本费用"></el-table-column>
							<el-table-column prop="loss_fee" label="固定损耗"></el-table-column>
							<el-table-column prop="other_fee" label="其他费用"></el-table-column>
							<el-table-column prop="remark" label="备注"></el-table-column>
						</el-table>
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
				tableData2: [],
				date: '',
				detailInfo: {},
				isShowDetail: false
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
				let requestData = {
					date: this.date
				}
				let list = await http.get({
					url: 'settle-account',
					data: requestData
				})
				if(list.code===4000&&list.data&&list.data.list){
					this.tableData = list.data.list;
				}
			},
			async getDetail(res){
				console.log(res)
				let detail = await http.get({
					url: 'settle-account/'+res.id,
					data: {}
				})
				if(detail.code===4000&&detail.data&&detail.data.record){
					this.detailInfo = detail.data.record;
					this.tableData2 = detail.data.list;
					this.isShowDetail = true;
				}
			},
			formatDate(){
                let time = new Date();
                let y = time.getFullYear();
                let m = time.getMonth();
				let d = time.getDate();
                return y+"-"+m;
            },
			async settlement(res){
				let requestData = {
					base_fee: res.base_fee,
					loss_fee: res.loss_fee,
					other_fee: res.other_fee,
					is_finished: 1
				}
				let settle = await http.put({
					url: 'settle-account/'+res.id,
					data: requestData
				})
				if(settle.code===4000){
					this.getList();
					Msg.prompt('结算完成');
				}
			}
		},
		created(){
			this.date = this.formatDate();
			this.getList();
			this.userInfo = JSON.parse(sessionStorage.getItem('userInfo')).record;
		},
		mounted(){
			
        }
	}
</script>