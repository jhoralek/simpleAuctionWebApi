module.exports = {
    outputDir: "wwwroot",
    publicPath: "/",
    chainWebpack: config => {
        config.entryPoints
            .clear()
            .end()
            .devtool("source-map")
            .entry("app")
            .add("./src/main.ts")
            .end()
            .resolve.alias.set("vue$", "vue/dist/vue.esm.js");
    }
};