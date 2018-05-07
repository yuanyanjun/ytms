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
					<el-menu default-active="6" class="el-menu-vertical-demo">
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
                            <el-table-column label="标签名" width="200">
                                <template slot-scope="scope">   
                                    <span v-show="!scope.row.isEdit">{{scope.row.name}}</span>
                                    <el-input v-model="scope.row.name" size="mini" class="long" v-show="scope.row.isEdit" placeholder="标签名"></el-input>
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
                            <span>确定要删除【{{currentTag}}】吗？</span>
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
                currentTag: ''
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
                let tagInfo = await http.get({
                    url: 'room-tag',
                    data: {}
                })
                if(tagInfo.code===4000&&tagInfo.data){
                    this.tableData = tagInfo.data;
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
            editName(index){
                this.tableData[index].isEdit = true;
            },
            deleteRoom(row){
                this.currentId = row.id;
                this.currentTag = row.name;
                this.dialogVisible = true;
            },
            async confirmEdit(row,index){
                let tagData = {
                    name: row.name,
                    sort: row.sort
                }
                if(row.id){
                    tagData.id = row.id;
                }
                let addRoom = await http.post({
                    url: 'room-tag',
                    data: tagData
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
            closeDelete(){
                this.currentId = null;
                this.currentTag = '';
                this.dialogVisible = false;
            },
            async qrDelete(){
                let del = await http.delete({
                    url: 'room-tag/'+this.currentId,
                    data: {}
                })
                if(del.code===4000){
                    this.closeDelete();
                    this.getList();
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