<template>
  <div id="app">
    <div id="nav">
      <router-link
        v-bind:to="{ name: 'home' }"
        class="nav-item"
        v-if="$store.state.token != ''"
        >Home</router-link
      >
      <router-link
        v-bind:to="{ name: 'pantry' }"
        class="nav-item"
        v-if="$store.state.token != ''"
        >Pantry</router-link
      >
      <router-link
        v-bind:to="{ name: 'logout' }"
        v-if="$store.state.token != ''"
        class="nav-item"
        >Logout</router-link
      >
    </div>
    <router-view />
  </div>
</template>


<style scoped>
#nav {
  padding-left: 20px;
}

.nav-item {
  max-width: 110px;
  height: 40px;
  display: inline-block;
  padding: 0.3em 1.2em;
  margin: 20px 0.3em 0.3em 0;
  border-radius: 2px;
  box-sizing: border-box;
  text-decoration: none;
  font-family: "Roboto", sans-serif;
  font-size: 20px;
  font-weight: 300;
  color: #ffffff;
  background-color: #141414;
  transition: all 0.2s;
  caret-color: transparent;
}

.nav-item:hover {
  max-width: 110px;
  height: 50px;
  display: inline-block;
  padding: 0.3em 1.2em;
  margin: 0 0.3em 0.3em 0;
  border-radius: 2px;
  box-sizing: border-box;
  text-decoration: none;
  font-family: "Roboto", sans-serif;
  font-size: 20px;
  font-weight: 300;
  color: #ffffff;
  background-color: #000000;
  transition: all 0.2s;
  caret-color: transparent;
}

#app {
  background: linear-gradient(to right, #ff4b2b, #ff416c);
}
</style>