//import axios from 'axios'

// axios.defaults.baseURL = 'http://39.156.1.68:26379';
// axios.defaults.headers.post['content-Type'] = 'appliction/x-www-form-urlencoded';
import Qs from 'qs'
var config= {
      baseURL:"http://back.yinyuem.com/back/",
      headers:{
            "Content-Type": 'application/x-www-form-urlencoded',
      },
      transformRequest: [function (data) {
            data = Qs.stringify(data);
            return data;
          }],
      transformResponse: [function (data) {
            return JSON.parse(data)
      }],
}
// if(process.env.NODE_ENV!='development'){
//       config.baseURL="/tsh";
// }

export default config;