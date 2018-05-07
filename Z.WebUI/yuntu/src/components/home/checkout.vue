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
					<!--<div class="part_one">
						<div class="m"><span class="tab">客源类型：</span><span>202-普卡</span></div>-->
						<!--<div class="m">
							<span class="tab">入住时间：</span><span>2018-03-01</span>
							<span class="tab" style="margin-left:20px;">离店时间：</span>
							<el-date-picker size="small" v-model="leaveDate" type="date" placeholder="选择日期"></el-date-picker>
							<span class="tab" style="margin-left:20px;">房价：</span><span>4614</span>
						</div>-->
						<!--<div class="m">
							<span class="tab">营业日：</span>
							<el-date-picker size="small" v-model="value5" type="datetimerange" start-placeholder="开始日期" end-placeholder="结束日期" :default-time="['12:00:00']"></el-date-picker>
							<el-button size="mini" type="warning">查询</el-button>
						</div>
						<div class="m">
							<span class="tab">共计消费：</span><span>4822</span><span class="tab" style="margin-left:20px;">欠费：</span><span class="co_green">-4822</span>
							<span class="tab" style="margin-left:20px;">预授权：</span><span>0</span><span class="tab" style="margin-left:20px;">发票：</span><span class="co_green">0</span>
						</div>
					</div>-->
					<div class="part_two">
						<!--<el-table ref="multipleTable" :data="tableData3" style="width: 100%">
							<el-table-column type="selection" width="55"></el-table-column>
							<el-table-column label="项目">
								<template slot-scope="scope">{{ scope.row.project }}</template>
							</el-table-column>
							<el-table-column prop="money" label="消费"></el-table-column>
							<el-table-column prop="pay" label="付款" show-overflow-tooltip></el-table-column>
							<el-table-column prop="date" label="营业日"></el-table-column>
							<el-table-column prop="time" label="时间" show-overflow-tooltip></el-table-column>
							<el-table-column prop="number" label="房号"></el-table-column>
							<el-table-column prop="operator" label="操作人" show-overflow-tooltip></el-table-column>
							<el-table-column prop="shift" label="班次" show-overflow-tooltip></el-table-column>
						</el-table>-->
						<template>
							<el-table :data="tableData" style="width: 100%">
								<el-table-column prop="day_time" label="日期"></el-table-column>
								<el-table-column prop="name" label="姓名"></el-table-column>
								<el-table-column label="基本房费">
									<template slot-scope="scope">
										<span v-show="!scope.row.isEdit">{{scope.row.base_fee}}</span>
										<el-input size="mini" v-show="scope.row.isEdit" v-model="scope.row.base_fee" class="mon"></el-input>
									</template>
								</el-table-column>
								<el-table-column label="固定损耗">
									<template slot-scope="scope">
										<span v-show="!scope.row.isEdit">{{scope.row.loss_fee}}</span>
										<el-input size="mini" v-show="scope.row.isEdit" v-model="scope.row.loss_fee" class="mon"></el-input>
									</template>
								</el-table-column>
								<el-table-column label="其他费用">
									<template slot-scope="scope">
										<span v-show="!scope.row.isEdit">{{scope.row.other_fee}}</span>
										<el-input size="mini" v-show="scope.row.isEdit" v-model="scope.row.other_fee" class="mon"></el-input>
									</template>
								</el-table-column>
								<el-table-column label="操作">
									<template slot-scope="scope">
										<i v-show="!scope.row.isEdit" class="el-icon-edit icon co_blue" @click="editRow(scope.$index)"></i>
										<i v-show="!scope.row.isEdit" class="el-icon-delete icon co_red" @click="deleteRow(scope.row)"></i>
										<i v-show="scope.row.isEdit" class="el-icon-check icon co_green" @click="confirmEdit(scope.row,scope.$index)"></i>
										<i v-show="scope.row.isEdit" class="el-icon-minus icon co_red" @click="cancelEdit(scope.$index,scope.row)"></i>
									</template>
								</el-table-column>
							</el-table>
							<div class="add_btn" v-show="tableData&&tableData.length>0">
								<el-button size="mini" @click="addRow">添加</el-button>
							</div>
						</template>
						<el-dialog title="提示" :visible.sync="dialogVisible" width="25%">
                            <span>确定要删除该条信息吗？</span>
                            <span slot="footer" class="dialog-footer">
                            <el-button size="mini" @click="closeDelete">取 消</el-button>
                            <el-button size="mini" type="primary" @click="qrDelete">确 定</el-button>
                            </span>
                        </el-dialog>
						<!--<div class="pagin">
							<el-pagination background layout="prev, pager, next" :total="totalPage" @current-change="flipPage"></el-pagination>
						</div>-->
					</div>
					<div class="btn_box">
						<el-button size="medium" type="primary" @click="checkOut">退 房</el-button>
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
				tableDataCopy: [],
				roomId: this.$route.query.roomId,
				leaveDate: '2018-03-29',
				totalPage: 1,
				currentId: null,
				dialogVisible: false
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
					is_checked: 1,
					per_page: 300
				}
				let list = await http.get({
					url: 'reserve',
					data: requestData
				})
				var that = this;
				if(list.code===4000&&list.data&&list.data.data){
					this.tableData = list.data.data;
					this.totalPage = list.data.last_page;
					this.tableData.map(function(item, index){
						that.$set(item,'isEdit',false);
                    	that.$set(item,'isAdd',false);
					});
					this.tableDataCopy = JSON.parse(JSON.stringify(this.tableData));
				}
			},
			flipPage(){

			},
			addRow(){
				let tempObj = {
					day_time: this.formatDate(this.tableData[this.tableData.length-1].day_time),
					name: this.tableData[0].name,
					base_fee: this.tableData[0].base_fee,
					loss_fee: this.tableData[0].loss_fee,
					other_fee: '0.00',
					phone: this.tableData[0].phone,
					isEdit: true,
                    isAdd: true
				}
				this.tableData.push(tempObj);
			},
			async deleteRow(res){
				if(!res.id){
					this.tableData.pop();
					return;
				}
				let del = await http.delete({
					url: 'reserve/'+res.id,
					data: {}
				})
				if(del&&del.code===4000){
					this.getList();
				}
			},
			async checkOut(){
				if(this.tableData.length==0){
					return;
				}
				let ids = [];
				this.tableDataCopy.map(function(item, index){
					ids.push(item.id);
				})
				let out = await http.post({
					url: 'reserve-batch-finish',
					data: {
						reserve_ids: ids.join(',')
					}
				})
				if(out.code===4000){
					Msg.prompt('办理成功');
					this.$router.push({path:'/index'});
				}
			},
			editRow(index){
				this.tableData[index].isEdit = true;
			},
			deleteRow(row){
				this.currentId = row.id;
                this.dialogVisible = true;
			},
			async confirmEdit(row,index){
				let roomData = {
                    base_fee: row.base_fee,
                    loss_fee: row.loss_fee,
					other_fee: row.other_fee,
					is_finished: 1
                }
                if(row.id){
					let editRoom = await http.put({
						url: 'reserve/'+row.id,
						data: roomData
					})
					if(editRoom.code===4000){
						this.tableData[index].isEdit = false;
						this.getList();
					}
                }else{
					roomData.status = 3;
					roomData.room_id = this.roomId;
					roomData.start = this.formatDate(row.day_time);
					roomData.end = this.formatDate(row.day_time);
					roomData.day = 1;
					roomData.name = row.name;
					roomData.phone = row.phone;
					let addRow = await http.post({
						url: 'reserve',
						data: roomData
					});
					if(addRow&&addRow.code===4000){
						this.tableData[index].isEdit = false;
						this.getList();
					}
				}
			},
			cancelEdit(index, row){
                if(row.isAdd){
                    this.tableData[index].base_fee = '';
                    this.tableData[index].loss_fee = '';
					this.tableData[index].other_fee = '';
                    return;
                }
                this.tableData[index].base_fee = this.tableDataCopy[index].base_fee;
                this.tableData[index].loss_fee = this.tableDataCopy[index].loss_fee;
				this.tableData[index].other_fee = this.tableDataCopy[index].other_fee;
                this.tableData[index].isEdit = false;
            },
			async qrDelete(){
                let del = await http.delete({
                    url: 'reserve/'+this.currentId,
                    data: {}
                })
                if(del.code===4000){
                    this.closeDelete();
                    this.getList();
                }
            },
            closeDelete(){
                this.currentId = null;
                this.dialogVisible = false;
            },
			formatDate(date){
                let temp = (new Date(date)).getTime()+24*3600*1000;
				let time = new Date(temp);
                let y = time.getFullYear();
                let m = time.getMonth() + 1;
				let d = time.getDate();
				let h = time.getHours();
				let mm = time.getMinutes();
				let s = time.getSeconds();
                return y+"-"+(m<10?('0'+m):m)+"-"+(d<10?('0'+d):d)+" "+(h<10?('0'+h):h)+":"+(mm<10?('0'+mm):mm)+":"+(s<10?('0'+s):s);
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