import Vue from 'vue'
import Router from 'vue-router'
import Index from '@/components/home/index'
import MyInfo from '@/components/home/reserve'
import MyStep from '@/components/home/checkin'
import MultipleCheck from '@/components/home/multiplecheck'
import Dialog from '@/components/home/dialog'
import Guestroom from '@/components/song/guestroom'
import User from '@/components/song/user'
import Owner from '@/components/song/owner'
import Overall from '@/components/song/overall'
import Room from '@/components/song/room'
import RankList from '@/components/home/input'
import History from '@/components/home/checkout'
import Settlement from '@/components/home/settlement'
import TagManage from '@/components/song/tagmanage'
import Login from '@/components/home/login'


Vue.use(Router)

export default new Router({
  routes: [{
      path: '/',
      component: Login
    },
    {
      path: '/index',
      component: Index
    },
    {
      path: '/reserve',
      component: MyInfo
    },
    {
      path: '/checkin',
      component: MyStep
    },
    {
      path: '/settlement',
      component: Settlement
    },
    {
      path: '/guestroom',
      component: Guestroom
    },
    {
      path: '/user',
      component: User
    },
    {
      path: '/owner',
      component: Owner
    },
    {
      path: '/input',
      component: RankList
    },
    {
      path: '/checkout',
      component: History
    },
    {
      path: '/overall',
      component: Overall
    },
    {
      path: '/room',
      component: Room
    },
    {
      path: '/tagmanage',
      component: TagManage
    },
    {
      path: '/multiplecheck',
      component: MultipleCheck
    },
    {
      path: '/dialog',
      component: Dialog
    }
  ]
})
