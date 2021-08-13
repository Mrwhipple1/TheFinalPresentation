<template>
  <div id="login" class="text-center">
    <div class="overlay"></div>
    <div class="popup">
      <div class="right-container">
        <h2></h2>
        <img
          src="https://i.imgur.com/6JguKva.png"
          alt="plannr logo"
          class="logo-image"
        />
        <div class="right-inner-container">
          <p class="description">
            Welcome to Plannr! Your number one tool for planning meals! With
            Plannr you can add ingredients, create meals, and add them together
            to create any recipe you want! Easily assign those recipes to dates
            and times to map out what you will eat for the week, its that
            simple!
          </p>
        </div>
      </div>
      <div class="left-container">
        <form class="form-signin" @submit.prevent="login">
          <h1 class="h3 mb-3 font-weight-normal" id="sign-in-message">
            Sign In To Access Your Plannr Account!
          </h1>
          <div
            class="alert alert-danger"
            role="alert"
            id="invalid-credentials"
            v-if="invalidCredentials"
          >
            Invalid username and password!
          </div>
          <div
            class="alert alert-success"
            role="alert"
            id="register-success"
            v-if="this.$route.query.registration"
          >
            Thank you for registering, please sign in.
          </div>
          <input
            type="text"
            id="username"
            class="form-control"
            placeholder="Username"
            v-model="user.username"
            required
            autofocus
          />
          <input
            type="password"
            id="password"
            class="form-control"
            placeholder="Password"
            v-model="user.password"
            required
          />
          <router-link :to="{ name: 'register' }" class="register"
            >Need an account?</router-link
          >
          <button class="submitbtn" type="submit">Sign in</button>
        </form>
      </div>
    </div>
  </div>
</template>

<script>
import authService from "../services/AuthService";

export default {
  name: "login",
  components: {},
  data() {
    return {
      user: {
        username: "",
        password: "",
      },
      invalidCredentials: false,
    };
  },
  methods: {
    login() {
      authService
        .login(this.user)
        .then((response) => {
          if (response.status == 200) {
            this.$store.commit("SET_AUTH_TOKEN", response.data.token);
            this.$store.commit("SET_USER", response.data.user);
            this.$router.push("/");
          }
        })
        .catch((error) => {
          const response = error.response;

          if (response.status === 401) {
            this.invalidCredentials = true;
          }
        });
    },
  },
};
</script>

<style scoped>
input:-webkit-autofill,
input:-webkit-autofill:hover,
input:-webkit-autofill:focus,
textarea:-webkit-autofill,
textarea:-webkit-autofill:hover,
textarea:-webkit-autofill:focus,
select:-webkit-autofill,
select:-webkit-autofill:hover,
select:-webkit-autofill:focus {
  border: 1px solid rgb(24, 24, 24);
  -webkit-text-fill-color: rgb(201, 201, 201);
  -webkit-box-shadow: 0 0 0px 1000px rgb(59, 59, 59) inset;
  transition: background-color 5000s ease-in-out 0s;
}

.overlay {
  position: fixed;
  top: 0px;
  left: 0px;
  width: 100%;
  /* opacity: 10%;
  backdrop-filter: blur(6px); */
  backdrop-filter: blur(3px);
  background: #9494946e;
  height: 100vh;
  z-index: 1;
  display: block;
}

.popup {
  display: grid;
  grid-template-columns: 50% 50%;
  grid-template-areas: "left-container right-container";
  border-radius: 20px;
  position: absolute;
  top: 50%;
  left: 50%;
  transform: translate(-50%, -50%);
  width: 800px;
  height: 600px;
  z-index: 2;
  background-color: rgb(34, 34, 34);
  box-shadow: 5px 5px 3px rgba(0, 0, 0, 0.2);
}

.right-container {
  display: grid;
  grid-area: right-container;
  grid-template-columns: auto;
  grid-template-areas:
    "logo"
    "description";
  background: linear-gradient(to right, #ff4b2b, #ff416c);
  border-radius: 0px 20px 20px 0px;
}

.right-inner-container {
  max-width: 90%;
  justify-self: center;
  grid-area: description;
  font-size: 20px;
}

.left-container {
  display: grid;
  grid-area: left-container;
}

.form-signin {
  display: grid;
  grid-template-columns: auto;
  grid-template-rows: 100px 50px 50px 25px;
  grid-template-areas:
    "message"
    "username"
    "password"
    "register"
    "submitbtn";
  max-width: 95%;
  justify-self: center;
  align-self: center;
  margin: 20px 0px 100px 0px;
}

#sign-in-message {
  grid-area: message;
  font-weight: bold;
  max-width: 300px;
  font-size: 23px;
  text-align: left;
  font-family: "Roboto", sans-serif;
  caret-color: transparent;
  color: rgb(250, 249, 249);
}

.description {
  font-family: "Roboto", sans-serif;
  text-align: left;
  font-weight: 200;
  font-size: 27px;
  text-align: center;
}

#register-success {
  grid-area: reg-suc;
}

#invalid-credentials {
  grid-area: invalid-credentials;
}

#username {
  grid-area: username;
}

#password {
  grid-area: password;
}

.register {
  grid-area: register;
  font: bold 13px Arial;
  margin: 0px 0px 0px 0px;
  width: 120px;
  height: 15px;
  text-decoration: none;
  background-color: #2c2c2c;
  color: #dadada;
  padding: 2px 6px 2px 6px;
  border-radius: 2em;
  caret-color: transparent;
  text-align: center;
  text-justify: auto;
}
.register:hover {
  grid-area: register;
  font: bold 13px Arial;
  margin: 0px 0px 0px 0px;
  width: 120px;
  height: 15px;
  text-decoration: none;
  background-color: #5a5a5a;
  color: #e6e6e6;
  padding: 2px 6px 2px 6px;
  border-radius: 2em;
  caret-color: transparent;
  text-align: center;
  text-justify: auto;
}

form input {
  margin: 2px;
  height: 50px;
  color: #333333;
}

.form-control {
  background-color: rgb(41, 41, 41);
  border: none;
  height: 40px;
  color:white;
}

.submitbtm {
  grid-area: submitbtn;
}

form button {
  max-width: 110px;
  height: 30px;
  margin: 0px 20px 0px 0px;
  border: #242424;
  border-radius: 2em;
  box-sizing: border-box;
  text-decoration: none;
  font-family: "Roboto", sans-serif;
  font-weight: bold;
  font-size: 17px;
  color: #b9b9b9;
  background-color: #303030;
  text-align: center;
  transition: all 0.2s;
  caret-color: transparent;
}

form button:hover {
  max-width: 110px;
  height: 30px;
  margin: 0px 20px 0px 0px;
  border: #ffffff;
  border-radius: 2em;
  box-sizing: border-box;
  text-decoration: none;
  font-family: "Roboto", sans-serif;
  font-weight: 300;
  font-size: 17px;
  color: #ffffff;
  background-color: #575656;
  text-align: center;
  transition: all 0.2s;
  caret-color: transparent;
}

.logo-image {
  max-width: 400px;
  grid-area: logo;
  margin-top: 20px;
}

.alert-danger {
  font-size: 13px;
  font-weight: bold;
  font-family: "Roboto", sans-serif;
  color: rgb(255, 0, 0);
  margin: 0px 0px 10px 0px;
}

.alert-success {
  font-size: 13px;
  font-weight: bold;
  font-family: "Roboto", sans-serif;
  color: rgb(209, 209, 209);
  margin: 0px 0px 10px 0px;
}

@media only screen and (max-width: 800px) {
  .popup {
    display: grid;
    grid-template-columns: auto;
    grid-template-areas:
      "left-container"
      "right-container";
    border-radius: 20px;
    position: absolute;
    top: 50%;
    left: 50%;
    transform: translate(-50%, -140%);
    width: 400px;
    height: 250px;
    z-index: 2;
    background-color: rgb(34, 34, 34);
    border-radius: 20px 20px 0px 0px;
    box-shadow: 5px 5px 3px rgba(0, 0, 0, 0.2);
    grid-template-rows: 250px 500px;
  }

  .form-signin {
    display: grid;
    grid-template-columns: auto auto;
    grid-template-areas:
      "message message"
      "username password"
      "register register"
      "submitbtn submitbtn";

    grid-template-rows: 100px 50px 25px;
  }

  .right-container {
    width: 400px;
    height: 550px;
    border-radius: 0px 0px 20px 20px;
    box-shadow: 5px 5px 3px rgba(0, 0, 0, 0.2);
  }
}
</style>

