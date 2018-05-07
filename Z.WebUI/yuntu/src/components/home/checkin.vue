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
                        border-top: 1px solid #ddd;
                        border-bottom: 1px solid #ddd;
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
                        .m{
                              margin-bottom: 10px;
                              .el-input{
                                    width: 200px;
                                    margin-right: 5px;
                              }
                              .el-textarea{
                                    margin-top: 5px;
                              }
                        }
                  }
                  .table{
                        .cash{
                              width: 100px;
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
                                    <!--<div class="box1">
                                          <span class="tab">入住类型：</span>
                                          <div class="btns">
                                                <el-button size="small" type="primary">正常</el-button> 
                                                <el-button size="small">时租</el-button>  
                                                <el-button size="small">自用</el-button>
                                                <el-button size="small">免费</el-button>
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
                                    <!--<div class="box4">
                                          <div class="date_bar">
                                                <span class="tab">到店时间：</span>
                                                <div style="display:inline-block;"><el-date-picker size="small" v-model="value2" type="datetime" placeholder="选择日期时间"></el-date-picker></div>
                                                <span class="tab" style="margin-left:20px;">预离时间：</span>
                                                <div style="display:inline-block;"><el-date-picker size="small" v-model="value2" type="datetime" placeholder="选择日期时间"></el-date-picker></div>-->
                                                
                                                <!--<span class="tab" style="margin-left:20px;">入住天数：</span>
                                                <el-input size="small" v-model="needDays"></el-input>
                                          </div>
                                          <div class="date_bar">
                                                <span class="tab" style="margin-left:20px;">担保方式：</span>
                                                <el-dropdown size="small" split-button>无
                                                      <el-dropdown-menu slot="dropdown">
                                                            <el-dropdown-item>无</el-dropdown-item>
                                                            <el-dropdown-item>银行</el-dropdown-item>
                                                      </el-dropdown-menu>
                                                </el-dropdown>
                                          </div>
                                    </div>-->
                                    <div class="table">
                                          <el-tabs type="border-card">
                                                <el-tab-pane label="预定入住">
                                                      <el-table :data="tableData" style="width: 100%">
                                                            <el-table-column prop="day_time" label="时间"></el-table-column>
                                                            <el-table-column prop="name" label="姓名"></el-table-column>
                                                            <el-table-column prop="phone" label="电话"></el-table-column>
                                                            <el-table-column prop="base_fee" label="基本房费"></el-table-column>
                                                            <el-table-column prop="loss_fee" label="固定损耗"></el-table-column>
                                                            <el-table-column label="押金"> 
                                                                  <template slot-scope="scope"><el-input size="mini" v-model="scope.row.cash_fee" class="cash"></el-input></template>
                                                            </el-table-column>
                                                            <el-table-column label="操作">
                                                                  <template slot-scope="scope"><el-button size="mini" type="warning" @click="checkIn(scope.row)">入住</el-button></template>
                                                            </el-table-column>
                                                      </el-table>
                                                </el-tab-pane>
                                          </el-tabs>
                                          
                                          <!--<div class="pagin">
                                                <el-pagination background layout="prev, pager, next" :total="totalPage" @current-change="flipPage"></el-pagination>
                                          </div>-->
                                    </div>
                                    <div class="box6">
                                          <el-tabs type="border-card">
                                                <el-tab-pane label="直接入住">
                                                      <div class="m">
                                                            <el-date-picker size="small" v-model="directInfo.dateRange" type="daterange" value-format="yyyy-MM-dd" range-separator="至" start-placeholder="到店时间" @change="changeDate" end-placeholder="预离时间"></el-date-picker>
                                                            <b class="co_red">*</b><br>
                                                      </div>
                                                      <div class="m">
                                                            姓名：<el-input size="small" v-model="directInfo.name" placeholder="联系人姓名"></el-input><b class="co_red">*</b>
                                                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                            联系电话：<el-input size="small" v-model="directInfo.phone" placeholder="联系电话"></el-input><b class="co_red">*</b>
                                                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                            押金：<el-input size="small" v-model="directInfo.cash_fee" placeholder="￥0.00"></el-input>
                                                      </div>
                                                      <div class="m">
                                                            订单备注<el-input type="textarea" v-model="directInfo.remark"></el-input>
                                                      </div>
                                                      <el-button size="mini" type="success" @click="directIn">入住</el-button>
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
                        roomId: this.$route.query.roomId,
                        dateRange: [],
                        needDays: null,
                        totalPage: 1,
                        tableData: [],
                        directInfo: {
                              dateRange: [],
                              name: '',
                              phone: '',
                              cash_fee: 0,
                              remark: ''
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
                  changeDate(){
                        let a = new Date(this.directInfo.dateRange[0]);
                        let b = new Date(this.directInfo.dateRange[1]);
                        this.needDays = (b-a)/1000/3600/24; 
                  },
                  async getList(){
                        let requestData = {
                              room_id: this.roomId,
                              is_checked: 0,
                              per_page: 300
                        }
                        if(this.dateRange&&this.dateRange.length>0){
                              requestData.start = this.dateRange[0];
                              requestData.end = this.dateRange[1];
                        }
                        let list = await http.get({
                              url: 'reserve',
                              data: requestData
                        })
                        if(list.code===4000&&list.data&&list.data.data){
                              this.tableData = list.data.data;
                              this.totalPage = list.data.last_page;
                        }
                  },
                  flipPage(){},
                  async checkIn(res){
                        let check = await http.put({
                              url: 'reserve/'+res.id,
                              data: {
                                    cash_fee: parseInt(res.cash_fee),
                                    is_checked: 1
                              }
                        })
                        if(check&&check.code===4000){
                              Msg.prompt('办理成功');
                              this.$router.push({path:'/index'});
                        }
                  },
                  async directIn(){
                        var that = this;
                        if(!this.directInfo.dateRange[0]){
					Msg.prompt('请选择时间');
					return;
				}
                        if(!this.directInfo.name){
					Msg.prompt('请输入姓名');
					return;
				}
                        if(!this.directInfo.phone){
					Msg.prompt('请输入电话');
					return;
				}
                        var phoneReg=/^[1][3,4,5,7,8][0-9]{9}$/;
				if(!phoneReg.test(that.directInfo.phone)){
					Msg.prompt('请输入有效电话号码');
				}
                        let directData = {
                              room_id: this.roomId,
                              start: this.directInfo.dateRange[0],
                              end: this.directInfo.dateRange[1],
                              day: this.needDays,
                              name: this.directInfo.name,
                              phone: this.directInfo.phone,
                              status: 2,
                              is_checked: 1
                        }
                        if(this.directInfo.cash_fee){
                              directData.cash_fee = this.directInfo.cash_fee;
                        }
                        if(this.directInfo.remark){
                              directData.remark = this.directInfo.remark;
                        }
                        let direct = await http.post({
                              url: 'reserve',
                              data: directData
                        })
                        if(direct&&direct.code===4000){
                              Msg.prompt('办理成功');
                              this.$router.push({path:'/index'});
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



