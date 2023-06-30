//stress test to test the system under pressure

import http from 'k6/http';
import { sleep } from 'k6';
import * as config from './config.js';

//ramp up to 200  users
export const options = {
    stages: [
        { duration: '5s', target: 5 },
        { duration: '30s', target: 5 },
        { duration: '5s', target: 20 },
        { duration: '30s', target: 20 },
        { duration: '5s', target: 100 },
        { duration: '30s', target: 100 },
        { duration: '5s', target: 200 },
        { duration: '30s', target: 200 },
        { duration: '5s', target: 0 },
    ],
    thresholds: {
        http_req_failed: ['rate<0.01'],     //http errors should be < 1%
        http_req_duration: ['p(95)<600'],
    },
};

export default () => {
    http.get(config.API_BASE_URL);
    sleep(1);
};