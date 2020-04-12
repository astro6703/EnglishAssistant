const path = require('path');

module.exports = {
    mode: 'none',
    entry: {
        index: './src/home/index.ts'
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
        path: path.resolve(__dirname, 'bundles'),
        filename: '[name].bundle.js'
    }
};