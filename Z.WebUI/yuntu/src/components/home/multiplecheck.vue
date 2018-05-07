<style lang="less" scoped>
      html,body{
           background: #efefef;
      }
      .section{
            margin-top: 26px; 
            .b_box{
                  background-color: #efefef;
                  padding: 10px 20px;
                  .box1{
                        .tab{
                              display: inline-block;
                        }
                        .btns{
                              display: inline-block;
                        }
                  }
                  .box2{
                        margin: 15px 0 10px;
                        padding-left: 10px;
                        background-color: #c2e7b0;
                        height: 42px;
                        line-height: 42px;
                        overflow: hidden;
                        padding: 0 20px;
                        .left{
                              float: left;
                        }
                        .right{
                              float: right;
                              .in{
                                    display: inline-block;
                              }
                        }
                  }
                  .box4{
                        padding: 5px 0;
                        margin: 10px 0;
                        .date_bar{
                              .el-input{
                                    width: 200px;
                              }
                        }
                  }
                  .box5{
                        .el-input{
                              width: 30px;
                              margin-right: 5px;
                        }
                        .el-icon-edit{
                              color: #409eff;
                              margin-left: 5px;
                              font-size: 16px;
                        }
                  }
                  .box6{
                        margin: 15px 0;
                        .el-input{
                              width: 200px;
                              margin-right: 5px;
                        }
                        .inner{
                              background-color: #fff;
                              padding: 10px 0;
                              .el-textarea{
                                    margin-top: 5px;
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
					<el-menu default-active="1" class="el-menu-vertical-demo">
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
                              <div class="b_box">
                                    <div class="box4">
                                          <div class="date_bar">
                                                <el-date-picker size="small" v-model="dateRange" type="daterange" value-format="yyyy-MM-dd" range-separator="至" start-placeholder="预抵时间" @change="changeDate" end-placeholder="预离时间"></el-date-picker>
                                                </el-input><b class="co_red">*</b>
                                          </div>
                                    </div>
                                    <el-tabs type="border-card">
                                          <el-tab-pane label="可预定房间">
                                                <el-table ref="multipleTable" :data="tableData" style="width: 100%" @selection-change="handleSelectionChange">
                                                      <el-table-column type="selection" width="55"></el-table-column>
                                                      <el-table-column prop="room_no" label="房间编号"></el-table-column>
                                                      <!--<el-table-column prop="base_fee" label="房间类型"></el-table-column>-->
                                                      <el-table-column prop="floor_num" label="客房楼层"></el-table-column>
                                                      <el-table-column prop="bed_num" label="床位数"></el-table-column>
                                                      <el-table-column prop="base_fee" label="基本费用"></el-table-column>
                                                      <el-table-column prop="address" label="地址"></el-table-column>
                                                      <el-table-column prop="area" label="客房面积"></el-table-column>
                                                      <!--<el-table-column prop="base_fee" label="客房配置"></el-table-column>-->
                                                </el-table>
                                          </el-tab-pane>
                                    </el-tabs>
                                    <div class="box6">
                                          <el-tabs type="border-card">
                                                <el-tab-pane label="预定人信息">
                                                      姓名：<el-input size="small" v-model="guest" placeholder="联系人姓名"></el-input><b class="co_red">*</b>
                                                      &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                      联系电话：<el-input size="small" v-model="phone" placeholder="联系电话"></el-input></el-input><b class="co_red">*</b>
                                                      &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                      押金：<el-input size="small" v-model="cash_fee" placeholder="￥0.00"></el-input></el-input>
                                                      <div class="inner">
                                                            订单备注<el-input type="textarea" v-model="remark"></el-input>
                                                      </div>
                                                      <el-button class="btn" size="small" type="success" @click="reserve">预定</el-button>
                                                </el-tab-pane>
                                          </el-tabs>
                                    </div>      
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
                        dateRange: [],
                        needDays: null,
                        guest: '',
                        phone: '',
                        remark: '',
                        multipleSelection: [],
                        cash_fee: 0
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
                        var sendData = {};
                        if(this.dateRange.length==0){
                              sendData.start = this.nowTime;
                              sendData.end = this.nowTime;
                        }else{
                              sendData.start = this.dateRange[0];
                              sendData.end = this.dateRange[1];
                        }
                        let list = await http.get({
                              url: 'room-except-reserve',
                              data: sendData
                        })
                        if(list.code===4000&&list.data&&list.data.list){
                              this.tableData = list.data.list;
                        }
                  },
                  handleSelectionChange(val) {
                        this.multipleSelection = val;
                  },
                  changeDate(){
                        let a = new Date(this.dateRange[0]);
                        let b = new Date(this.dateRange[1]);
                        this.needDays = (b-a)/1000/3600/24;
                        this.getList();
                  },
                  async reserve(){
                        var that = this;
                        if(!this.dateRange[0]){
					Msg.prompt('请选择时间');
					return;
				}
                        if(!this.guest){
					Msg.prompt('请输入姓名');
					return;
				}
                        if(!this.phone){
					Msg.prompt('请输入电话');
					return;
				}
                        var phoneReg=/^[1][3,4,5,7,8][0-9]{9}$/;
				if(!phoneReg.test(that.phone)){
					Msg.prompt('请输入有效电话号码');
				}
                        if(this.multipleSelection.length==0){
                              Msg.prompt('请选择房间');
					return;
                        }
                        var roomIds = [];
                        this.multipleSelection.map(function(item, index){
                              roomIds.push(item.id);
                        });
                        let requestData = {
                              room_id: roomIds.join(","),
                              start: this.dateRange[0],
                              end: this.dateRange[1],
                              day: this.needDays,
                              name: this.guest,
                              phone: this.phone,
                              status: 1
                        }
                        if(this.remark){
                              requestData.remark = this.remark;
                        }
                        if(this.cash_fee){
                              requestData.cash_fee = this.cash_fee;
                        }
                        let rese = await http.post({
                              url: 'reserve',
                              data: requestData
                        })
                        if(rese.code===4000){
                              Msg.prompt("预定成功");
                              this.$router.push({path:'/index'});
                        }
                  }
            },
            created(){
                  this.getList();
            },
            mounted(){
                  
            }
      }


</script>