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
                        // border-top: 1px solid #ddd;
                        // border-bottom: 1px solid #ddd;
                        padding: 5px 0;
                        margin: 10px 0;
                        .date_bar{
                              margin: 5px 0;
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
					<el-menu default-active="2" class="el-menu-vertical-demo">
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
                                    <el-tabs type="border-card">
                                          <el-tab-pane label="已预定">
                                                <el-table :data="tableData" style="width: 100%">
                                                      <el-table-column prop="day_time" label="时间"></el-table-column>
                                                      <el-table-column prop="name" label="姓名"></el-table-column>
                                                      <el-table-column prop="phone" label="电话"></el-table-column>
                                                      <el-table-column prop="base_fee" label="基本房费"></el-table-column>
                                                      <el-table-column prop="loss_fee" label="固定损耗"></el-table-column>
                                                      <el-table-column prop="cash_fee" label="押金"></el-table-column>
                                                      <el-table-column label="操作">
                                                            <template slot-scope="scope"><el-button size="mini" type="warning" @click="removeOrder(scope.row)">取消预定</el-button></template>
                                                      </el-table-column>
                                                </el-table>
                                          </el-tab-pane>
                                    </el-tabs>
                                    <!--<div class="box1">
                                          <span class="tab">入住类型：</span>
                                          <div class="btns">
                                                <el-button size="small" type="primary">正常</el-button> 
                                                <el-button size="small">自用</el-button>
                                                <el-button size="small">免费</el-button>
                                                <el-button size="small">旅行团</el-button>  
                                                <el-button size="small">会议团</el-button>
                                                <el-button size="small">长包</el-button>  
                                          </div>
                                    </div>
                                    <div class="box2">
                                          <div class="left">
                                                <el-radio-group v-model="radio">
                                                      <el-radio :label="1">非会员</el-radio>
                                                      <el-radio :label="2">个人会员</el-radio>
                                                      <el-radio :label="3">协议公司</el-radio>
                                                      <el-radio :label="4">订房中心/中介</el-radio>
                                                </el-radio-group>
                                          </div>
                                          <div class="right">
                                                <div class="in"><el-input size="small" placeholder="请输入内容" class="key"></el-input></div>
                                                <div class="in">
                                                      <el-button size="small" type="success">查询</el-button>
                                                      <el-button size="small" type="warning">会员注册</el-button>
                                                </div>
                                          </div>
                                    </div>
                                    <div class="box3">
                                          <span class="tab">当前状态：</span>
                                          <span class="co_green">非会员</span>
                                          <span class="tab" style="margin-left:20px;">相关说明：</span>
                                          <span class="co_green">未查到相关会员信息，按门市价格计价</span>
                                    </div>-->
                                    <div class="box4">
                                          <div class="date_bar">
                                                <!--<span class="tab">预抵时间：</span>
                                                <div style="display:inline-block;"><el-date-picker size="small" v-model="value1" type="datetime" placeholder="选择日期时间"></el-date-picker></div>
                                                <span class="tab" style="margin-left:20px;">预离时间：</span>
                                                <div style="display:inline-block;"><el-date-picker size="small" v-model="value2" type="datetime" placeholder="选择日期时间"></el-date-picker></div>-->
                                                <el-date-picker size="small" unlink-panels="true" v-model="dateRange" type="daterange" value-format="yyyy-MM-dd" range-separator="至" start-placeholder="预抵时间" @change="changeDate" end-placeholder="预离时间"></el-date-picker>
                                                </el-input><b class="co_red">*</b>
                                                <!--<span class="tab" style="margin-left:20px;">预住天数：</span>
                                                <el-input size="small" v-model="needDays"></el-input>
                                                </el-input><b class="co_red">*</b>-->
                                          </div>
                                          <!--<div class="date_bar">
                                                <span class="tab">入住天数：</span>
                                                <el-input size="small" placeholder="请输入内容" prefix-icon="el-icon-search"></el-input>
                                                <span class="tab" style="margin-left:20px;">担保方式：</span>
                                                <el-dropdown size="small" split-button>无
                                                      <el-dropdown-menu slot="dropdown">
                                                            <el-dropdown-item>无</el-dropdown-item>
                                                            <el-dropdown-item>银行</el-dropdown-item>
                                                      </el-dropdown-menu>
                                                </el-dropdown>
                                                <span class="tab" style="margin-left:20px;">保留时间：</span>
                                                <el-checkbox v-model="checked"></el-checkbox>
                                          </div>-->
                                    </div>
                                    <!--<div class="box5">
                                          <el-table :data="tableData" style="width: 100%">
                                                <el-table-column prop="type" label="房型"></el-table-column>
                                                <el-table-column prop="name" label="优惠价/门市价">
                                                      <template slot-scope="scope">
                                                            <el-input size="mini"></el-input>/234
                                                            <i class="el-icon-edit"></i>
                                                      </template>
                                                </el-table-column>
                                                <el-table-column prop="canOrder" label="可订数"></el-table-column>
                                                <el-table-column prop="canExceed" label="可超数"></el-table-column>
                                                <el-table-column prop="reserve" label="预定间数" width="160">
                                                      <template slot-scope="scope">
                                                            <el-input-number size="mini"></el-input-number>
                                                      </template>
                                                </el-table-column>
                                                <el-table-column prop="notAllot" label="未分配间数" width="180"></el-table-column>
                                                <el-table-column prop="address" label="操作" width="180">
                                                      <template slot-scope="scope">
                                                            <el-button size="mini" type="warning">排房</el-button>
                                                      </template>
                                                </el-table-column>
                                          </el-table>
                                    </div>-->
                                    <div class="box6">
                                          <el-tabs type="border-card">
                                                <el-tab-pane label="联系人信息">
                                                      姓名：<el-input size="small" v-model="guest" placeholder="联系人姓名"></el-input><b class="co_red">*</b>
                                                      &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                      联系电话：<el-input size="small" v-model="phone" placeholder="联系电话"></el-input></el-input><b class="co_red">*</b>
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
                        tableData: [{
                              type: '豪华大床',
                              canOrder: 3,
                              reserve: 0,
                              canExceed: 4,  
                              notAllot: "无",
                        }],
                        roomId: this.$route.query.roomId,
                        dateRange: [],
                        needDays: null,
                        guest: '',
                        phone: '',
                        remark: ''
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
                        let list = await http.get({
                              url: 'reserve',
                              data: {
                                    room_id: this.roomId,
                                    is_checked: 0,
                                    per_page: 300
                              }
                        })
                        if(list.code===4000&&list.data&&list.data.data){
                              this.tableData = list.data.data;
                        }
                  },
                  changeDate(){
                        let a = new Date(this.dateRange[0]);
                        let b = new Date(this.dateRange[1]);
                        this.needDays = (b-a)/1000/3600/24;
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
                        let requestData = {
                              room_id: this.roomId,
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
                        let rese = await http.post({
                              url: 'reserve',
                              data: requestData
                        })
                        if(rese.code===4000){
                              Msg.prompt("预定成功");
                              this.$router.push({path:'/index'});
                        }
                  },
                  async removeOrder(row){
                        let del = await http.delete({
                              url: 'reserve/'+row.id,
                              data: {}
                        })
                        if(del.code===4000){
                              Msg.prompt('取消成功');
                              this.getList();
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



