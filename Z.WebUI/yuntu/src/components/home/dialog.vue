<style lang="less" scoped>
	.part_one{
		background-color: #efefef;
		padding: 10px 20px;
		border-radius: 3px;
		.m{
			margin: 5px 0;
		}
	}
	.part_two{
		.el-table{
			border: 1px solid #ddd;
			.el-input{
				width: 100px;
			}
			.icon{
				font-size: 18px;
				margin-right: 5px;
				cursor: pointer;
			}
		}
		.add_btn{
			padding: 10px;
			border:1px solid #ddd;
			border-top: none;
		}
	}
	.btn_box{
		margin-top: 30px;
		text-align: center;
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
					<el-menu default-active="3" class="el-menu-vertical-demo">
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
					<div class="part_two">
						<template>
							<el-table :data="tableData" style="width: 100%">
								<el-table-column prop="day_time" label="日期"></el-table-column>
								<el-table-column prop="base_fee" label="房价"></el-table-column>
								<el-table-column prop="loss_fee" label="固定损耗"></el-table-column>
								<el-table-column prop="other_fee" label="其他费用"></el-table-column>
                                <el-table-column prop="name" label="入住人姓名"></el-table-column>
                                <el-table-column prop="phone" label="联系电话"></el-table-column>
                                <el-table-column label="状态">
                                    <template slot-scope="scope">
                                        <span v-if="scope.row.finished_at">已结算</span>
                                        <span v-else>未结算</span>
                                    </template>
                                </el-table-column>
							</el-table>
						</template>
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
				roomId: this.$route.query.roomId
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
					room_id: this.roomId,
					is_checked: 2
				}
				let list = await http.get({
					url: 'reserve',
					data: requestData
				})
				var that = this;
				if(list.code===4000&&list.data&&list.data.data){
					this.tableData = list.data.data;
				}
			},
			
		},
		created(){
			this.getList();
			this.userInfo = JSON.parse(sessionStorage.getItem('userInfo')).record;
		},
		mounted(){
            
        }
	}
</script>