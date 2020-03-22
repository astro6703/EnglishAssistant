const path = require('path');

module.exports = {
    mode: 'none',
    entry: {
        index: './wwwroot/views/home/index/index.ts'
    },
    devtool: 'inline-source-map',
    module: {
        rules: [
            { test: /\.tsx?$/, use: 'ts-loader', exclude: /node_modules/ },
            { test: /\.s[ac]ss$/i, use: [ 'style-loader', 'css-loader', 'sass-loader' ] }
        ],
    },
    resolve: {
        extensions: [ '.ts' ],
    },
    output: {
        path:  path.join(__dirname, 'wwwroot', 'bundles'),
        filename: '[name].js'
    }
};