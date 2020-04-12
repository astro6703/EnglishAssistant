const webpackConfig = require('webpack-config');

module.exports = new webpackConfig.Config()
    .extend('./webpack.config.js')
    .merge({
        mode: 'development',
        devtool: 'source-map',
    });

