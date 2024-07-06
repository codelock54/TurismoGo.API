const routes = [
  {
    path: "/",
    component: () => import("layouts/MainLayout.vue"),
    children: [{ path: "", component: () => import("pages/IndexPage.vue") }],
  },
  {
    path: "/Actividad_publica",
    component: () => import("components/Empresa_Turismo/Actividad_publica.vue"),
  },
  {
    path: "/Visualiza_Actividad",
    component: () => import("components/Empresa_Turismo/Ver_actividades.vue"),
  },
  {
    path: "/:catchAll(.*)*",
    component: () => import("pages/ErrorNotFound.vue"),
  },
];

export default routes;
