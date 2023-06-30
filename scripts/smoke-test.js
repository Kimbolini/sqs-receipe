//Smoke Test to test under minimal load for a short period of time to identify
//apparent bugs or regressions 

import http from 'k6/http';
import { sleep } from 'k6';
import * as config from './config.js';

//vus is set to 1 (default), runs for 1 min, 95% of request should respond in <1s
export const options = {
    vus: 1,
    duration: '1m',
    thresholds: {
        http_req_failed: ['rate<0.01'],     //http errors should be < 1%
        http_req_duration: ['p(95)<1000']
    },
};

export default function () {
    http.get(config.API_BASE_URL);
    sleep(1);
}