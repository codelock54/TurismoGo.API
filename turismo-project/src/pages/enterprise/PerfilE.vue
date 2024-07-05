<template>
  <div class="q-pa-md">
    <q-card class="q-pa-sm">
      <q-card-section class="text-h6">
        Empresa
      </q-card-section>

      <q-card-section>
        <q-list bordered class="q-mb-sm q-pa-lg">
          <q-item class="q-pa-xs">
            <q-item-section>
              <q-item-label class="text-bold">Nombre:</q-item-label>
            </q-item-section>
            <q-item-section>
              <q-item-label>{{ empresa.nombre }}</q-item-label>
            </q-item-section>
          </q-item>

          <q-item class="q-pa-xs">
            <q-item-section>
              <q-item-label class="text-bold">RUC:</q-item-label>
            </q-item-section>
            <q-item-section>
              <q-item-label>{{ empresa.ruc }}</q-item-label>
            </q-item-section>
          </q-item>

          <q-item class="q-pa-xs">
            <q-item-section>
              <q-item-label class="text-bold">Dirección:</q-item-label>
            </q-item-section>
            <q-item-section>
              <q-item-label>{{ empresa.direccion }}</q-item-label>
            </q-item-section>
          </q-item>

          <q-item class="q-pa-xs">
            <q-item-section>
              <q-item-label class="text-bold">Teléfono:</q-item-label>
            </q-item-section>
            <q-item-section>
              <q-item-label>{{ empresa.telefono }}</q-item-label>
            </q-item-section>
          </q-item>

          <q-item class="q-pa-xs">
            <q-item-section>
              <q-item-label class="text-bold">Correo:</q-item-label>
            </q-item-section>
            <q-item-section>
              <q-item-label>{{ empresa.correo }}</q-item-label>
            </q-item-section>
          </q-item>

          <q-item class="q-pa-xs">
            <q-item-section>
              <q-item-label class="text-bold">Contraseña:</q-item-label>
            </q-item-section>
            <q-item-section>
              <q-item-label>{{ empresa.contrasena }}</q-item-label>
            </q-item-section>
          </q-item>
        </q-list>
      </q-card-section>

      <q-card-actions align="right">
        <q-btn icon="edit" @click="editEmpresa">Editar</q-btn>
      </q-card-actions>
    </q-card>
  </div>
</template>

<script>
import { ref } from 'vue'

export default {
  setup () {
    const empresa = ref({
      nombre: 'Acme Corp',
      ruc: '123456789',
      direccion: 'Av. Principal 123',
      telefono: '555-1234',
      correo: 'contacto@acme.com',
      contrasena: '********'
    })

    const editEmpresa = () => {
      // Implementar lógica de edición de empresa aquí
      console.log('Editar empresa')
    }

    return {
      empresa,
      editEmpresa
    }
  }
}
</script>

<style>
.text-bold {
  font-weight: bold;
}
.q-pa-xs {
  padding: 4px;
}
.q-mb-sm {
  margin-bottom: 8px;
}
</style>

