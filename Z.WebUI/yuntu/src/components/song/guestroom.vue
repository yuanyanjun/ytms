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
                }
				.owner{
					position: relative;
					.owner_panel{
						position: absolute;
						top: 36px;
						left: 0;
						width: 100%;
						background-color: #fff;
						z-index: 100;
						min-height: 50px;
						box-shadow: 0 1px 5px #ddd;
						.s{
							font-size: 12px;
							padding-left: 12px;
							line-height: 30px;
							cursor: pointer;
						}
						.s:hover{
							background-color: #ecf5ff;
						}
					}
				}
				.img_box{
					margin-top: 10px;
					padding: 0 20px;
					.tit{
						margin-bottom: 10px;
					}
					.add_btn{
						width: 50px;
						height: 50px;
						display: inline-block;
						border: 2px dashed #ccc;
						background: url(../../assets/images/add.png) no-repeat center center;
						cursor: pointer;
					}
				}
            }
		}
	}
	.detail{
		font-size: 12px;
		padding: 10px 10px 0;
		.tit{
			font-size: 14px;
		}
		.one{
			.n{
				margin: 4px 0;
			}
			.imgs{
				.avator{
					height: 100px;
					max-width: 120px;
					margin-right: 5px;
				}
			}
		}
		.two{
			.tit{
				margin-top: 10px;
				border-top: 1px solid #ddd;
				padding-top: 5px;
			}
			.ln{
				display: inline-block;
				margin-right: 50px;
			}
		}
	}
	#main{
		height: 250px;
	}
</style>
<template>
	<div>
		 <header-nav></header-nav>
		 <div class="section">
		 	<div style="margin-bottom:20px;">
				<el-menu default-active="1" class="el-menu-demo" mode="horizontal">
					<el-menu-item index="1">
						<router-link :to="{path:'/guestroom'}" class="sub" style="display:block;">系统设置</router-link>
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
						<el-button class="btn" size="mini" type="warning" @click="addRoom">新增</el-button>
					</div>
					<div class="table">
						<el-table :data="tableData" style="width: 100%">
							<el-table-column prop="room_no" label="客房编号"></el-table-column>
							<el-table-column prop="type.name" label="客房房型"></el-table-column>
							<el-table-column prop="floor_num" label="客房楼层"></el-table-column>
							<el-table-column prop="bed_num" label="床位数"></el-table-column>
							<el-table-column prop="roomTags" label="客房配置"></el-table-column>
							<el-table-column label="客房状态">
								<template scope="scope">{{scope.row.control_status==1?'闲':scope.row.control_status==2?'控':'住'}}</template>
							</el-table-column>
							<el-table-column label="操作" fixed="right">
								<template scope="scope">
									<el-popover v-model="scope.row.isShowDetail" ref="popover2" placement="left" width="400" trigger="click">
										<div class="detail">
											<div class="one">
												<div class="tit co_blue">基础信息</div>
												<div class="con">
													<div class="n">详细地址：{{scope.row.address}}</div>
													<div class="n">备注信息：{{scope.row.remark}}</div>
													<div class="n">创建人：{{scope.row.created_name}}</div>
													<div class="n">创建时间：{{scope.row.created_at}}</div>
													<div class="imgs">
														<img v-for="item in scope.row.images" :src="item.url" alt="" class="avator">
													</div>
												</div>
											</div>
											<!--<div class="two">
												<div class="tit co_blue">收益信息</div>
												<div class="ln">月入住率：<span class="co_green">89.03%</span></div>
												<div class="ln">月收益：<span class="co_green">89.03%</span></div>
												<div class="line">
													<div id="main" ref="main">222</div>
												</div>
											</div>-->
										</div>
									</el-popover>
									<el-button type="text" size="medium" @click='openDetail(scope.row)' v-popover:popover2>详情</el-button>
									<i class="el-icon-edit icon" @click="editRoom(scope.row)"></i>
									<i class="el-icon-delete icon" @click="deleteRoom(scope.row)"></i>
								</template>
							</el-table-column>
						</el-table>
						<el-dialog title="提示" :visible.sync="dialogVisible" width="25%">
                            <span>确定要删除该客房吗？</span>
                            <span slot="footer" class="dialog-footer">
                            <el-button size="mini" @click="closeDelete">取 消</el-button>
                            <el-button size="mini" type="primary" @click="qrDelete">确 定</el-button>
                            </span>
                        </el-dialog>
					</div>
					<div class="pagin">
						<el-pagination background layout="prev, pager, next" :total="totalCount" :page-size="pageSize" @current-change="flipPage"></el-pagination>
					</div>
					<div class="add_panel">
                        <el-dialog :title="operator" :visible.sync="dialogFormVisible">
                            <el-form :model="form" >
                                <el-row>
                                    <el-col :span="12">
										<el-form-item label="业主：" :label-width="formLabelWidth" class="w owner">
                                            <el-input v-model.lazy="owner" size="mini" @focus="chose=false"></el-input>
                                            <span class="co_red">*</span>
											<div class="owner_panel" v-show="searchOwner">
												<div class="s" v-for="v in ownerInfo" @click="chooseOwner(v.id,v.name)">{{v.name}}</div>
											</div>
                                        </el-form-item>
                                        <el-form-item label="客房编号：" :label-width="formLabelWidth" class="w">
                                            <el-input v-model="form.room_no" auto-complete="off" size="mini"></el-input>
                                            <span class="co_red">*</span>
                                        </el-form-item>
										<el-form-item label="客房类型：" :label-width="formLabelWidth" class="w">
											<el-select size="mini" v-model="form.room_type_id" placeholder="请选择">
												<el-option v-for="item in roomType" :key="item.id" :label="item.name" :value="item.id"></el-option>
											</el-select>
                                            <span class="co_red">*</span>
                                        </el-form-item>
										<el-form-item label="客房标签：" :label-width="formLabelWidth" class="w">
											<el-select size="mini" v-model="roomTagArr" placeholder="请选择" multiple>
												<el-option v-for="item in roomTag" :key="item.id" :label="item.name" :value="item.id"></el-option>
											</el-select>
                                        </el-form-item>
										<el-form-item label="客房楼层：" :label-width="formLabelWidth" class="w">
                                            <el-input v-model="form.floor_num" auto-complete="off" size="mini"></el-input>
                                            <span class="co_red">*</span>
                                        </el-form-item>
										<el-form-item label="物业费：" :label-width="formLabelWidth" class="w">
                                            <el-input v-model="form.property_fee" auto-complete="off" size="mini"></el-input>
                                            <span class="co_red">*</span>
                                        </el-form-item>
                                        <el-form-item label="平台扣点：" :label-width="formLabelWidth" class="w">
                                            <el-input v-model="form.platform_rate" auto-complete="off" size="mini"></el-input>
                                            <span class="co_red">*</span>
                                        </el-form-item>
										<el-form-item label="固定损耗：" :label-width="formLabelWidth" class="w">
                                            <el-input v-model="form.loss_fee" auto-complete="off" size="mini"></el-input>
                                            <span class="co_red">*</span>
                                        </el-form-item>
                                    </el-col>
                                    <el-col :span="12">
										<el-form-item label="房费：" :label-width="formLabelWidth" class="w">
                                            <el-input v-model="form.base_fee" auto-complete="off" size="mini"></el-input>
                                            <span class="co_red">*</span>
                                        </el-form-item>
										<el-form-item label="客房状态：" :label-width="formLabelWidth">
                                            <el-select size="mini" v-model="form.control_status" placeholder="请选择">
												<el-option v-for="item in roomStatus" :key="item.value" :label="item.label" :value="item.value"></el-option>
											</el-select>
                                        </el-form-item>
										<el-form-item label="客房床位：" :label-width="formLabelWidth">
                                            <el-input v-model="form.bed_num" auto-complete="off" size="mini"></el-input>
                                        </el-form-item>
										<el-form-item label="客房面积：" :label-width="formLabelWidth">
											<el-input v-model="form.area" auto-complete="off" size="mini"></el-input>
                                        </el-form-item>
										<el-form-item label="折扣价：" :label-width="formLabelWidth">
											<el-input v-model="form.discount_fee" auto-complete="off" size="mini"></el-input>
                                        </el-form-item>
										<el-form-item label="地址：" :label-width="formLabelWidth" class="w">
                                            <el-input v-model="form.address" auto-complete="off" size="mini"></el-input>
                                            <span class="co_red">*</span>
                                        </el-form-item>
										<el-form-item label="客房备注：" :label-width="formLabelWidth">
                                            <el-input type="textarea" v-model="form.remark" auto-complete="off" size="mini"></el-input>
                                        </el-form-item>
                                    </el-col>
                                </el-row>
								<div class="img_box">
									<el-upload size="mini" v-bind:action="config.baseURL+'upload'" :limit="limitNum" :file-list="imgArr" :headers="{token:userInfo?userInfo.token:null}" :on-success="getImgUrl" list-type="picture-card" :on-exceed="alertLimit" :on-remove="handleRemove">
										<i class="el-icon-plus"></i>
									</el-upload>

								</div>
                            </el-form>
                            <div slot="footer" class="dialog-footer">
                                <el-button size="mini" @click="cancelEdit">取 消</el-button>
                                <el-button size="mini" type="primary" @click="qrAddRoom">确 定</el-button>
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
	import VCalendar from '../calendar'
	import headerNav from '../header.vue'
	export default {
		data(){
            return {
				tableData: [],
				config: config,
				dialogFormVisible: false,
				operator: '新增客房信息',
                form: {
                    user_id: null,
                    room_no: '',
                    room_type_id: null,
                    floor_num: null,
                    property_fee: null,
                    platform_rate: null,
                    loss_fee: null,
                    base_fee: null,
					control_status: 1,
					bed_num: null,
					area: null,
					discount_fee: null,
					remark: '',
					address: ''
                },
                formLabelWidth: '120px',
				owner: '',
				keyWord: '',
				ownerInfo: [],
				searchOwner: false,
				chose: false, //选定
				roomType: [], //房屋类型
				roomStatus: [{
					value: 1,
					label: '闲'
				},{
					value: 2,
					label: '控'
				},{
					value: 3,
					label: '住'
				}], //房屋状态
				roomTag: [], //客房标签
				uploadImgList: [],
				userInfo:null,
				imgArr: [],
				roomTagArr: [],
				dialogVisible: false,
				currentId: null,
				currentPage: 1,
				totalCount: 1,
				pageSize: 15,
				limitNum: 1
			}
		},
		components: {
				VCalendar,
				headerNav
		},
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
			async owner(curVal,oldVal){
				let ownerInfo = await http.get({
					url: 'user',
					data: {
                        key: curVal
					}
				});
				if(ownerInfo&&ownerInfo.code===4000&&ownerInfo.data){
                    this.ownerInfo = ownerInfo.data.data;
					if(!this.chose){
						this.searchOwner = true;
					}
                }
			}
		},
		methods:{
			async lineChart(id){
				let chartTime = [];
				let chartData = [];
				let chart = await http.get({
					url: 'room-stat',
					data: {
						room_id: id
					}
				});
				if(chart&&chart.code===4000&&chart.list.length>0){

				}
				let option={
					xAxis: {
						type: 'category',
						data: ['Mon', 'Tue', 'Wed', 'Thu', 'Fri', 'Sat', 'Sun']
					},
					yAxis: {
						type: 'value'
					},
					grid: {
						left: 50,
						right: 20,
						top: 20
					},
					series: [{
						data: [820, 102, 901, 534, 405, 830, 920],
						type: 'line',
						itemStyle: {
							color: '#409eff'
						}
					}]
				}
				// 绘制图表
				setTimeout(()=>{
					var box=this.$refs.main
					var myChart = this.$echarts.init(box);
					myChart.setOption(option);
					console.log(myChart)
				},100)

				//

			},
			async getList(){
				let listData = {
					per_page: this.pageSize,
					page: this.currentPage
				}
				if(this.keyWord){
					listData.key = this.keyWord;
				}
				let roomList = await http.get({
					url: 'room',
					data: listData
				})
				if(roomList.code===4000&&roomList.data&&roomList.data.list){
					this.$set(this, 'totalCount', roomList.data.list.total);
					this.tableData = roomList.data.list.data;
					var that = this;
					this.tableData.map(function(item, index){
						that.$set(item, 'isShowDetail', false);
						if(item.tags&&item.tags.length>0){
							var tags = '';
							item.tags.map(function(v,k){
								tags+=v.name;
								if(k<item.tags.length-1){
									tags+='|';
								}
							});
							that.$set(item, 'roomTags', tags);
						}
					})
				}
			},
			chooseOwner(id, name){
				this.form.user_id = id;
				this.owner = name;
				this.searchOwner = false;
				this.chose = true;
			},
			async getRoomType(){
				let room = await http.get({
					url: 'room-type',
					data: {}
				});
				if(room.code===4000&&room.data){
                    this.roomType = room.data;
                }
			},
			async getRoomTags(){
				let tags = await http.get({
					url: 'room-tag',
					data: {}
				})
				if(tags.code===4000&&tags.data){
					this.roomTag = tags.data;
				}
			},
			async qrAddRoom(){
				if(!this.form.user_id){
					Msg.prompt('请输入业主');
					return;
				}
				if(!this.form.room_no){
					Msg.prompt('请输入客房编号');
					return;
				}
				if(!this.form.room_type_id){
					Msg.prompt('请选择客房类型');
					return;
				}
				if(!this.form.floor_num){
					Msg.prompt('请输入客房楼层');
					return;
				}
				if(!this.form.property_fee){
					Msg.prompt('请输入物业费');
					return;
				}
				if(!this.form.platform_rate){
					Msg.prompt('请输入平台扣点');
					return;
				}
				if(!this.form.loss_fee){
					Msg.prompt('请输入固定损耗');
					return;
				}
				if(!this.form.base_fee){
					Msg.prompt('请输入基本房费');
					return;
				}
				if(!this.form.address){
					Msg.prompt('请输入地址');
					return;
				}
				//let roomData = this.form;
				let roomData = {
					user_id: this.form.user_id,
					room_no: this.form.room_no,
					room_type_id: this.form.room_type_id,
					floor_num: this.form.floor_num,
					base_fee: this.form.base_fee,
					loss_fee: this.form.loss_fee,
					property_fee: this.form.property_fee,
					platform_rate: this.form.platform_rate,
					address: this.form.address
				};
				let tempArr = [];
				if(this.imgArr.length > 0){
					this.imgArr.map(function(item, index){
						tempArr.push(item.url);
					})
					roomData.room_images = tempArr.join(',');
				}
				if(this.currentId){
					roomData.id = this.currentId;
				}
				roomData.room_tags = this.roomTagArr.join(',');
				roomData.control_status = this.form.control_status;
				if(this.form.bed_num){
					roomData.bed_num = this.form.bed_num;
				};
				if(this.form.remark){
					roomData.remark = this.form.remark;
				};
				if(this.form.area){
					roomData.area = this.form.area;
				};
				if(this.form.discount_fee){
					roomData.discount_fee = this.form.discount_fee;
				};
				let add = await http.post({
					url: 'room',
					data: roomData
				})
				if(add.code===4000){
					this.cancelEdit();
					this.getList();
				}
			},
			cancelEdit(){
				this.dialogFormVisible = false;
				this.currentId = null;
			},
			handleRemove(file, fileList) {
				var imgList = JSON.parse(JSON.stringify(fileList));
				var that = this;
				imgList.map(function(item, index){
					if(item.response&&item.response.data){
						that.imgArr.push({name: item.response.data.name, url: item.response.data.url});
					}
				});
			},
			openDetail(row){
				row.isShowDetail = true;
			},
			getImgUrl(response, file, fileList){
				console.log(fileList)
				var imgList = JSON.parse(JSON.stringify(fileList));
				var that = this;
				imgList.map(function(item, index){
					if(item.response&&item.response.data){
						that.imgArr.push({name: item.response.data.name, url: item.response.data.url});
					}
				});

			},
			editRoom(row){
				this.operator = '修改客房信息';
				this.currentId = row.id;
				this.dialogFormVisible = true;
				this.form.user_id = row.user_id;//
				this.form.room_no = row.room_no;
				this.form.room_type_id = row.room_type_id;
				this.form.floor_num = parseInt(row.floor_num);
				this.form.property_fee = parseInt(row.property_fee);
				this.form.platform_rate = parseInt(row.platform_rate);
				this.form.loss_fee = parseInt(row.loss_fee);
				this.form.base_fee = parseInt(row.base_fee);
				this.form.control_status = row.control_status;
				this.form.bed_num = parseInt(row.bed_num);
				this.form.area = parseInt(row.area);
				this.form.discount_fee = parseInt(row.discount_fee);
				this.form.remark = row.remark;
				this.form.address = row.address;
				this.owner = row.user.name;
				this.searchOwner = false;
				var that = this;
				this.imgArr = [];
				if(row.images&&row.images.length>0){
					row.images.map(function(item, index){
						that.imgArr.push({name: 't', url: item.url});
					});
				}
				window.setTimeout(function(){
					that.searchOwner = false;
				},500);
				that.roomTagArr = [];
				if(row.tags&&row.tags.length>0){
					row.tags.map(function(item,index){
						that.roomTagArr.push(item.id);
					})
				}
			},
			deleteRoom(row){
				this.currentId = row.id;
				this.dialogVisible = true;
			},
			closeDelete(){
				this.currentId = null;
				this.dialogVisible = false;
			},
			async qrDelete(){
				let del = await http.delete({
					url: 'room/'+this.currentId,
					data: {}
				})
				if(del.code===4000){
					this.closeDelete();
					this.getList();
				}
			},
			flipPage(page){
				this.currentPage = page;
				this.getList();
			},
			async addRoom(){
				let info = await http.get({
					url:'config',
					data:{

					}
				})
                if(info&&info.code==4000&&info.data){
					this.form.platform_rate = parseInt(info.data.platform_rate);
					this.form.loss_fee = parseInt(info.data.loss_fee);
                }
				this.operator = '新增客房信息';
				this.form.user_id = null;
				this.form.room_no = '';
				this.form.room_type_id = null;
				this.form.floor_num = null;
				this.form.property_fee = null;
				this.form.base_fee = null;
				this.form.control_status = 1;
				this.form.bed_num = null;
				this.form.area = null;
				this.form.discount_fee = null;
				this.form.remark = '';
				this.form.address = '';
				this.imgArr = [];
				this.ownerInfo = [];
				this.owner = '';
				this.roomTagArr = [];
				this.dialogFormVisible = true;
				var that = this;
				window.setTimeout(function(){
					that.searchOwner = false;
				},500)
			},
			async getGlobalInfo(){
				let globalInfo = await http.get({
					url: 'config',
					data: {}
				})
				if(globalInfo&&globalInfo.code===4000&&globalInfo.data){
					this.limitNum = globalInfo.data.room_image_limit_num-0;
				}
			},
			alertLimit(){
				var that = this;
				Msg.alert('最多只能上传'+that.limitNum+'张图片');
			}
		},
		created(){
			this.getList();
			this.getRoomType();
			this.getRoomTags();
			this.getGlobalInfo();
			this.userInfo=JSON.parse(sessionStorage.getItem('userInfo'))
		},
		mounted(){

        }
	}
</script>
