import {createRouter,createWebHashHistory} from 'vue-router'

const routes= [
    {
        path: "/Login",
        name: "Login",
        component: () => import("../views/Login.vue")
    }
]

const router = createRouter({
    history: createWebHashHistory(),
    routes
})

// router.beforeEach((to,from,next) => {

//     const isLogin:Boolean = localStorage.token ? true : false;
    
//     if(to.path === "/login" || to.path === "/register"){
//         next()
//     }else {
//         isLogin ? next() : next("/login")
//     }
// })



export default router