<template>
  <div id="app">
    <router-view></router-view>
  </div>
</template>

<script>
export default {
  name: 'app'
}
</script>
<style lang="less">
  html,body{
    font-size: 14px;
  }
  .top{
    position: fixed;
    left: 0;
    top:0;
    width:100%;
    z-index: 100;
    background-color: #409eff;
    color: #fff;
    height: 26px;
    line-height: 26px;
    overflow: hidden;
    .left{
      float: left;
      margin-left: 20px;
      .g{
        margin-right: 30px;
      }
    }
    .right{
      float: right;
      margin-right: 20px;
    }
  }
  .section{
    position: absolute;
    top: 0;
    bottom: 0;
    left: 0;
    right: 0;
    margin-top: 26px;
    background-color: #fff;
    padding: 0 20px 20px;
    .container{
      position: absolute;
      left: 0;
      top: 80px;
      bottom: 0;
      width: 100%;
      .aside{
        display: inline-block;
        .sub{
          color: #666;
          display: block;
        }
        .is-active{
          .sub{
            color: #409eff;
          }
        }
      }
      .panel{
        position: absolute;
        top: 0;
        left: 180px;
        right: 20px;
        bottom: 20px;
        .pagin{
            text-align: center;
            position: absolute;
            left: 0;
            width: 100%;
            bottom: 0;
        }
      }
    }
  }
  .co_green{
    color: #67c23a;
  }
  .co_red{
    color: red;
  }
  .co_blue{
    color: #409eff;
  }
</style>
