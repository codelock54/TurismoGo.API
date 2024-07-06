module.exports = {
  devServer: {
    proxy: {
      "/api": {
        target: "http://localhost:5259",
        changeOrigin: true,
        pathRewrite: { "^/api": "" },
      },
    },
  },
};
