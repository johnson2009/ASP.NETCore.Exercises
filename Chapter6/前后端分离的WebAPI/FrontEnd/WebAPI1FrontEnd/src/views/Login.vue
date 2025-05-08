<template>
    <div>
        <fieldset>
            <legend>Login</legend>
            <label for="userName">用户名：</label>
            <input type="text" id="userName" v-model="state.LoginData.userName" />
            <label for="password">密码：</label>
            <input type="password" id="password" v-model="state.LoginData.password" />
            <input type="submit" value="登录" @click="loginSubmit" />
        </fieldset>
        <table v-if="state.processes.length > 0">
            <thead>
                <tr><th>进程 Id</th><th>进程名</th><th>内存占用</th></tr>
            </thead>
            <tbody>
                <tr v-for="p in state.processes" :key="p.Id">
                    <td>{{ p.Id }}</td>
                    <td>{{ p.processName }}</td>
                    <td>{{ p.workingSet64 }}KB</td>
                </tr>
            </tbody>
        </table>
    </div>
</template>
<script lang="ts" setup>
import axios from 'axios';
import { reactive, onMounted } from 'vue';

const state = reactive({
    LoginData: {
        userName: '',
        password: ''
    },
    processes: [] as ProcessInfo[]
});

interface ProcessInfo {
  Id: number;
  processName: string;
  workingSet64: number;
}

interface LoginResponse {
  isOK: boolean;
  processes: ProcessInfo[];
}

const loginSubmit = async () => {
    const payload = state.LoginData;
    const resp = await axios.post<LoginResponse>('http://localhost:5093/api/Login/Login', payload);
    const data = resp.data;
    if(!data.isOK) {
        alert("登录失败");
        return;
    }
    
    state.processes = data.processes;
}

</script>