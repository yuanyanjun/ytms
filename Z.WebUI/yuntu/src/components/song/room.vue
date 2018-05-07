<style lang="less" scoped>
	body{
		background-color: #efefef;
	}
	.section{
        .container{
            .panel{
                overflow-y: auto;
                .table{
                    .long{
                        width: 180px;
                    }
                    .short{
                        width: 100px;
                    }
                    .icon{
                        margin-right: 6px;
                        font-size: 20px;
                        cursor: pointer;    
                    }
                    .el-icon-check{
                        font-weight: bold;
                    }
                    .el-icon-minus{
                        font-weight: bold;
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
				<el-menu default-active="1" class="el-menu-demo" mode="horizontal">
					<el-menu-item index="1">
						<router-link :to="{path:'/room'}" class="sub" style="display:block;">系统设置</router-link>
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
                    <div class="table">
                        <el-table :data="tableData" style="width: 100%">
                            <el-table-column prop="" label="项目编号">
                                <template slot-scope="scope"><span>{{scope.$index+1}}</span></template> 
                            </el-table-column>
                            <el-table-column label="项目名称" width="200">
                                <template slot-scope="scope">   
                                    <span v-show="!scope.row.isEdit">{{scope.row.name}}</span>
                                    <el-input v-model="scope.row.name" size="mini" class="long" v-show="scope.row.isEdit" placeholder="项目名称"></el-input>
                                </template>
                            </el-table-column>
                            <el-table-column label="排序号">
                                <template slot-scope="scope">   
                                    <span v-show="!scope.row.isEdit">{{scope.row.sort}}</span>
                                    <el-input v-model="scope.row.sort" size="mini" class="short" v-show="scope.row.isEdit" placeholder="排序号"></el-input>
                                </template>
                            </el-table-column>
                            <el-table-column prop="created_name" label="创建人"></el-table-column>
                            <el-table-column prop="created_at" label="创建时间"></el-table-column>
                            <el-table-column width="120" label="操作">
                                <template slot-scope="scope">   
                                    <i v-show="!scope.row.isEdit" class="el-icon-edit icon co_blue" @click="editName(scope.$index)"></i>
                                    <i v-show="!scope.row.isEdit" class="el-icon-delete icon co_red" @click="deleteRoom(scope.row)"></i>
                                    <i v-show="scope.row.isEdit" class="el-icon-check icon co_green" @click="confirmEdit(scope.row,scope.$index)"></i>
                                    <i v-show="scope.row.isEdit" class="el-icon-minus icon co_red" @click="cancelEdit(scope.$index,scope.row)"></i>
                                </template>
                            </el-table-column>
                        </el-table>
                        <el-dialog title="提示" :visible.sync="dialogVisible" width="25%">
                            <span>确定要删除【{{currentRoom}}】的信息吗？</span>
                            <span slot="footer" class="dialog-footer">
                            <el-button size="mini" @click="closeDelete">取 消</el-button>
                            <el-button size="mini" type="primary" @click="qrDelete">确 定</el-button>
                            </span>
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
    import headerNav from '../header.vue'
	export default {
		data(){
            return {
                userInfo: '',
				tableData: [{
					name: '',
					sort: '',
                    creater: '',
					date: '',
                    isEdit: true
				}],
                tableDataCopy: [],
                dialogVisible: false,
                currentId: null,
                currentRoom: ''
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
			editName(index){
                this.tableData[index].isEdit = true;
            },
            async confirmEdit(row,index){
                let roomData = {
                    name: row.name,
                    sort: row.sort
                }
                if(row.id){
                    roomData.id = row.id;
                }
                let addRoom = await http.post({
                    url: 'room-type',
                    data: roomData
                })
                if(addRoom.code===4000){
                    this.tableData[index].isEdit = false;
                    this.getList();
                }
            },
            cancelEdit(index, row){
                if(row.isAdd){
                    this.tableData[index].name = '';
                    this.tableData[index].sort = '';
                    return;
                }
                this.tableData[index].name = this.tableDataCopy[index].name;
                this.tableData[index].sort = this.tableDataCopy[index].sort;
                this.tableData[index].isEdit = false;
            },
            async getList(){
                let roomInfo = await http.get({
                    url: 'room-type',
                    data: {}
                })
                if(roomInfo.code===4000&&roomInfo.data){
                    this.tableData = roomInfo.data;
                }
                var that = this;
                this.tableData.map(function(item, index){
                    that.$set(item,'isEdit',false);
                    that.$set(item,'isAdd',false);
                })
                this.tableData.push({
					name: '',
					sort: '',
                    created_name: '',
					created_at: '',
                    isEdit: true,
                    isAdd: true
				});
                this.tableDataCopy = JSON.parse(JSON.stringify(this.tableData));
            },
            deleteRoom(row){
                this.currentId = row.id;
                this.currentRoom = row.name;
                this.dialogVisible = true;
            },
            async qrDelete(){
                let del = await http.delete({
                    url: 'room-type/'+this.currentId,
                    data: {}
                })
                if(del.code===4000){
                    this.closeDelete();
                    this.getList();
                }
            },
            closeDelete(){
                this.currentId = null;
                this.currentRoom = '';
                this.dialogVisible = false;
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