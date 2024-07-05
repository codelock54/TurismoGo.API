const routes = [
  {
    path: '/',
    component: () => import('layouts/MainLayout.vue'),
    children: [
      { path: '', component: () => import('components/auth/LoginM.vue') },
      { path: 'registerE', component: () => import('components/auth/RegisterE.vue') },
      { path: 'registerU', component: () => import('components/auth/RegisterU.vue') }

    ]
  },
  {
    path: '/perfil1',
    component: () => import('layouts/ELayaout.vue'),
    children: [
      { path: 'perfilE', component: () => import('pages/enterprise/PerfilE.vue') },
      { path: 'actividadesE', component: () => import('src/pages/enterprise/TablaActividadesE.vue') },
      { path: 'listadoE', component: () => import('pages/enterprise/ListadoUsuarios.vue') }
    ]
  },
  {
    path: '/perfil2',
    component: () => import('layouts/ULayout.vue'),
    children: [
      { path: 'perfilU', component: () => import('pages/user/PerfilU.vue') },
      { path: 'actividadesU', component: () => import('src/pages/user/TablaActividadesU.vue') }
    ]
  },

  { path: '/principalE', component: () => import('pages/enterprise/PrincipalE.vue') },
  { path: '/principalU', component: () => import('pages/user/PrincipalU.vue') },
  { path: '/principalA', component: () => import('pages/adm/PrincipalA.vue') },

  //AQUI COLOCAS TUS PATHS DE ACUERDO A LO

  {
    path: '/:catchAll(.*)*',
    component: () => import('pages/ErrorNotFound.vue')
  }
]

export default routes
