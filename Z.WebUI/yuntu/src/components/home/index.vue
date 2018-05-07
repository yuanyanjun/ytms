<style lang="less" scoped>
      html,body{
            background: #efefef;
      }
      .cont{
            position: relative;
      }
      .sidebar{
            width: 280px;
            display: inline-block;
            min-height: 400px;
            border: 1px solid #ddd;
            .tit{
                  height: 30px;
                  line-height: 30px;
                  background-color: #ecf5ff;
                  padding-left: 10px;
                  color: #409eff;
            }
            .input_box{
                  padding: 10px;
            }
            .tags{
                  margin: 0 10px;
                  .t{
                        color: #e6a23c;
                  }
                  .tag_box{
                        font-size: 12px;
                        margin: 5px 0;
                        .el-icon-error{
                              transform: scale(.8);
                              margin-left: 2px;
                              color: #666;
                        }
                        .num{
                              color: #00c1af;
                              font-weight: bold;
                        }
                        .co{
                              display: inline-block;
                              width: 10px;
                              height: 10px;
                              vertical-align: middle;
                              margin-right: 2px;
                              position: relative;
                              top: -1px;
                        }
                        .red{
                              background-color: #f56c6c;
                        }
                        .green{
                              background-color: #67c23a;
                        }
                        .blue{
                              background-color: #409eff;
                        }
                        .camel{
                              background-color: #734c19;
                        }
                        .tag{
                              margin: 2px;
                              padding: 1px 5px;
                              display: inline-block;
                        }
                        .tag:hover{
                              background-color: #e6a23c;
                              border-radius: 30px;
                        }
                  }
            }
      }
      .panel{
            .filter_box{
                  position: relative;
                  .f{
                        margin-bottom: 10px;
                        .active{
                              color: #3a8ee6;
                              border-color: #3a8ee6;
                        }
                  }
                  .sear{
                        position: absolute;
                        right: 0;
                        top: 0;
                        .el-input{
                              width: 200px;
                        }
                  }
            }
            .room_box{
                  background-color: #efefef;
                  position: relative;
                  height: 80%;   
                  padding: 12px 20px;  
                  overflow-y: auto;
                  .room_box:after{
                        content: '';
                        display: block;
                        clear: both;
                  }
                  .room{
                        float: left;
                        width: 160px;
                        height: 100px;
                        color: #fff;
                        padding: 10px 20px;
                        margin-right: 5px;
                        margin-bottom: 3px;
                        border-radius: 5px;
                        .room_no{
                              font-size: 16px;
                        }
                        .n{
                              font-size: 12px;
                              margin: 5px 0 4px;
                        }
                        .state{
                              font-size: 14px;
                        }
                        .operation{
                              margin-top: 10px;
                              position: relative;
                              .op{
                                    font-size: 14px;
                                    cursor: pointer;
                                    margin-right: 3px;
                                    color: #fff;
                              }
                              .dialog{
                                    position: absolute;
                                    right: 0;
                              }
                        }
                  }
                  .room.red{
                        background-color: #f56c6c;
                  }
                  .room.green{
                        background-color: #67c23a;
                  }
                  .room.blue{
                        background-color: #409eff;
                  }
                  .room.yellow{
                        background-color: #e6a23c;
                  }
            }
      }
      .detail{
            .status{
                  .labs{
                        margin: 5px 0;
                        .lab{
                              display: inline-block;
                              text-align: center;
                              font-size: 12px;
                              margin: 3px 5px;
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
					<el-menu class="el-menu-vertical-demo">
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
                        <div class="panel home">
                              <div class="filter_box">
                                    <div class="sear">
                                          <el-input v-model="keyWord" size="mini" placeholder="请输入内容"></el-input>
                                          <el-button size="mini" type="primary" @click="getList">搜索</el-button>
                                    </div>
                                    <div class="f">
                                          房态：<el-button :class="{active:controlId==item.value}" size="mini" plain v-for="item in roomStatus" @click="chooseStatus(item.value)">{{item.label}}</el-button>
                                    </div>
                                    <div class="f">
                                          房型：<el-button :class="{active:typeId==item.id}" size="mini" plain v-for="item in roomType" @click="chooseType(item.id)">{{item.name}}</el-button>
                                    </div>
                              </div>
                              <div class="room_box">
                                    <div class="room" v-bind:class="{green:item.control_status==1,yellow:item.control_status==2,red:item.control_status==3}" v-for="(item,index) in roomList">
                                          <!--<el-popover :value="item.isShowMore" placement="right-end" width="200" trigger="hover">
                                                <div class="detail">
                                                      <div class="status">
                                                            <div class="name">{{item.room_no}}{{item.room_type}}</div>
                                                            <div class="labs">
                                                                  <div class="lab"><router-link :to="{path:'/reserve',query:{roomId: item.id}}"><b class="el-icon-time"></b><div>预定</div></router-link></div>
                                                                  <div class="lab"><router-link :to="{path:'/checkin',query:{roomId: item.id}}"><b class="el-icon-time"></b><div>入住</div></router-link></div>
                                                                  <div class="lab"><router-link :to="{path:'/checkout',query:{roomId: item.id}}"><b class="el-icon-time"></b><div>退房</div></router-link></div>
                                                            </div>
                                                      </div>
                                                </div>
                                          </el-popover>-->
                                          <div>
                                                <div class="room_no">{{item.room_no}}{{item.room_type}}</div>
                                                <div class="n">{{item.user.name}}</div>
                                                <div class="state"><span>{{item.control_status==1?'闲':item.control_status==2?'控':'住'}}</span></div>
                                                <div class="operation">
                                                      <router-link :to="{path:'/reserve',query:{roomId: item.id}}" v-show="item.control_status==1||item.control_status==2"><span class="op">预定</span></router-link>
                                                      <router-link :to="{path:'/checkin',query:{roomId: item.id}}" v-show="item.control_status==1||item.control_status==2"><span class="op">入住</span></router-link>
                                                      <router-link :to="{path:'/checkout',query:{roomId: item.id}}" v-show="item.control_status==3"><span class="op">退房</span></router-link>
                                                      <router-link :to="{path:'/dialog',query:{roomId: item.id}}"><span class="op dialog">日志</span></router-link>
                                                </div>
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
                  document.title="工作台";
                  return {
                        userInfo:'',
                        per_page:300,
                        currentPage:1,
                        roomList: [],
                        input: '',
                        keyWord: '',
                        roomStatus: [{
					value: 1,
					label: '闲'
				},{
					value: 2,
					label: '控'
				},{
					value: 3,
					label: '住'
				}],
                        roomType: [],
                        controlId: null,
                        typeId: null
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
                        let listData = {
                              per_page: this.per_page
                        }
                        if(this.keyWord){
                              listData.key = this.keyWord;
                        }
                        if(this.controlId){
                              listData.control_status = this.controlId;
                        }
                        if(this.typeId){
                              listData.type_id = this.typeId;
                        }
                        let list = await http.get({
                              url: 'room',
                              data: listData
                        })
                        if(list.code===4000&&list.data&&list.data.list&&list.data.list.data){
                              let l = list.data.list.data;
                              l.map((item,index)=>{
                                    item.isShowMore=false;
                                    this.roomType.map((v,k)=>{
                                          if(v.id==item.room_type_id){
                                                this.$set(item, 'room_type', v.name);
                                          }
                                    })
                              })
                              this.roomList=l;
                        }
                  },
                  showMore(){
                        alert(11);
                  },
                  async getRoomType(){
                        let roomType = await http.get({
                              url: 'room-type',
                              data: {}
                        })
                        if(roomType.code===4000&&roomType.data){
                              this.roomType = roomType.data;
                        }
                  },
                  chooseStatus(id){
                        if(this.controlId==id){
                              this.controlId = null;
                              this.getList();
                              return;
                        }
                        this.controlId = id;
                        this.getList();
                  },
                  chooseType(id){
                        if(this.typeId==id){
                              this.typeId = null;
                              this.getList();
                              return;
                        }
                        this.typeId = id;
                        this.getList();
                  }
            },
            created(){
                  this.getRoomType();
                  this.getList();
                  this.userInfo = JSON.parse(sessionStorage.getItem('userInfo')).record;
            }
      }

</script>


