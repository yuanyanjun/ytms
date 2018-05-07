<style scoped>
.top {
    position: fixed;
    left: 0;
    top: 0;
    width: 100%;
    z-index: 100;
    background-color: #409eff;
    color: #fff;
    height: 26px;
    line-height: 26px;
    overflow: hidden;
}
.top .left {
    float: left;
    margin-left: 20px;
}
.top .right {
    float: right;
    margin-right: 20px;
}
.top .left .g {
    margin-right: 30px;
}
.top .right .check_out{
    cursor: pointer;
    margin-left: 30px;
    color: #fff;
}
</style>
<template>
    <div class="top">
            <div class="left"><span class="g">云途民宿酒店</span><span class="g">营业时间：{{nowTimeHead}}</span></div>
            <div class="right">
                <span class="g">操作人：{{userInfoHead.name}}</span>
                <a href="javascript:void(0);" class="g check_out" @click="loginOut">退出</a>
            </div>
    </div>
</template>
<script>
export default {
    props: {

    },
    data(){
        return {
            userInfoHead: {}
        }
    },
    computed: {
            nowTimeHead(){
                let time = new Date();
                let y = time.getFullYear();
                let m = time.getMonth() + 1;
                let d = time.getDate();
                return y+"-"+m+"-"+d;
            }
    },
    methods: {
        loginOut(){
            this.$router.push({path:'/'});
            sessionStorage.removeItem('userInfo');
        }
    },
    mounted: function(){
        this.userInfoHead = JSON.parse(sessionStorage.getItem('userInfo')).record;
    }
}
</script>