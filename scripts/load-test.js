//Load test to assess the system performance under normal and peak conditions 

import http from 'k6/http';
import { sleep } from 'k6';
import * as config from './config.js';

//increase traffic with different stages
//"normal" load: 5 users, peak: 20
export const options = {
    stages: [
        { duration: '5s', target: 5 },      //ramp up to 5 users over 5s
        { duration: '30s', target: 5 },     //stay at 5 users for 30s
        { duration: '5s', target: 20 },     //ramp up to 20 users over 5s
        { duration: '30s', target: 20 },    //stay at 20 users for 30s
        { duration: '5s', target: 5 },      //ramp down to 5 users over 5s
        { duration: '30s', target: 5 },     //stay at 5 users for 30s
        { duration: '5s', target: 0 },      //ramp down to 0 users over 5s
    ],
    thresholds: {
        http_req_failed: ['rate<0.01'],     //http errors should be < 1%
        http_req_duration: ['p(95)<600'],   //95% of response times must be below 600ms
    },
};

export default () => {
    http.get(config.API_BASE_URL);
    sleep(1);
};