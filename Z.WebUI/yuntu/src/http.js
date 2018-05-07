import axios from 'axios'
import config from './config'
var getConfig=()=>{
    let userInfo=sessionStorage.getItem('userInfo')
    if(userInfo&&userInfo.length>0){
        config.headers.token=JSON.parse(userInfo).token
    }
    return config;
}
class Http {
    post(params) {        
        return axios.post(params.url,params.data,getConfig())
    }
    put(params) {        
        return axios.put(params.url,params.data,getConfig())
    }
    delete(params) {        
        return axios.delete(params.url,getConfig())
    }
    
    get(params) {
        var query='';
        if(params&&typeof params =='object'){
            var keys=Object.keys(params.data)
            if(params.data&&keys.length>0){
                keys.map((item,index)=>{
                    if(index==0){
                        query=`?${item}=${params.data[item]}`
                    }else{
                        query+=`&${item}=${params.data[item]}`
                    }
                
                })
            }
        }
       
        return axios.get(params.url+query,getConfig())
    }
}

axios.interceptors.response.use((response)=>{
    if(response.status){
        let data = response.data;
        if(data.code===4009){
            Msg.alert('登录超时');
            window.router.push({path:'/'})
        }else if(data.code!=4000){
            Msg.prompt(data.msg)
            
        }else{
            return data
        }
        
    }
})
export default Http;