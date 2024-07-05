<template>
  <q-page class="q-pa-md">
    <q-card class="q-gutter-md">
      <q-card-section>
        <h2 class="login-title">Iniciar Sesión</h2>
        <div class="user-type-toggle">
          <div>
            <input
              type="radio"
              id="userTypeUser"
              value="user"
              v-model="userType"
            />
            <label for="userTypeUser">        Usuario</label>
          </div>
          <div>
            <input
              type="radio"
              id="userTypeCompany"
              value="company"
              v-model="userType"
            />
            <label for="userTypeCompany">       Empresa</label>
          </div>
          <div>
            <input
              type="radio"
              id="userTypeAdm"
              value="adm"
              v-model="userType"
            />
            <label for="userTypeAdm">       Adm</label>
          </div>
        </div>

        <q-form @submit="submitForm">
          <q-input
            v-model="formData.email"
            label="Correo electrónico"
            outlined
            dense
          />
          <q-input
            v-model="formData.password"
            label="Contraseña"
            type="password"
            outlined
            dense
          />
          <q-btn
            type="submit"
            color="primary"
            label="Iniciar sesión"
            class="q-mt-md"
          />
        </q-form>
      </q-card-section>
    </q-card>

    <q-card class="q-gutter-md">
      <q-card-section class="q-pt-md">
        <div class="text-center">
          <p class="q-mb-sm">¿No tienes una cuenta?</p>
          <q-btn @click="goToRegister" color="secondary" label="Registrarse" />
        </div>
      </q-card-section>
    </q-card>
  </q-page>
</template>

<script>
export default {
  data() {
    return {
      userType: "user", // Por defecto, usuario
      formData: {
        email: "",
        password: "",
      },
    };
  },
  methods: {
    submitForm() {
      // Lógica para enviar el formulario de login
      console.log("Formulario enviado", this.formData);
      // Aquí podrías agregar la lógica para enviar los datos a tu backend
      if (this.userType === "user") {
        this.$router.push("principalU");
      } else if (this.userType === "company") {
        this.$router.push("principalE");
      } else if (this.userType === "adm") {
        this.$router.push("principalA");
      }
    },
    goToRegister() {
      // Lógica para enviar el formulario de login
      console.log("Formulario enviado", this.formData);
      // Aquí podrías agregar la lógica para enviar los datos a tu backend
      if (this.userType === "user") {
        this.$router.push("registerU");
      } else if (this.userType === "company") {
        this.$router.push("registerE");
      }
    },
  },
};
</script>

<style scoped>
.q-card {
  max-width: 350px;
  margin: auto;
  background-color: #fff;
  border-radius: 8px;
  box-shadow: 0px 0px 20px rgba(0, 0, 0, 0.1);
}

.q-card-section {
  padding: 20px;
}

.q-input {
  margin-bottom: 15px;
}

.q-btn {
  width: 100%;
}

.user-type-toggle {
  text-align: center;
  margin-bottom: 20px;
}

.user-type-toggle div {
  display: inline-block;
  margin-right: 30px;
}

.text-center {
  text-align: center;
}

.q-mt-md {
  margin-top: 20px;
}

.q-mb-sm {
  margin-bottom: 10px;
}

.login-title {
  text-align: center;
  font-weight: 400;
  margin-bottom: 20px;
  font-size: 40px;
  color: #333; /* Cambia el color según tu diseño */
}
</style>
