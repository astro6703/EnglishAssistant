﻿const path = require('path');
const miniCssExtractPlugin = require('mini-css-extract-plugin');

module.exports = {
    entry: {
        'shared/layout': './src/shared/layout.ts',
        'home/index': './src/home/index.ts',
        'account/login': './src/account/login.ts',
        'account/create': './src/account/create.ts'
    },
    module: {
        rules: [
            { test: /\.tsx?$/, loader: 'ts-loader', exclude: /node_modules/ },
            { test: /\.s[ac]ss$/i, use: [ miniCssExtractPlugin.loader, 'css-loader', 'resolve-url-loader', 'sass-loader' ] },
            { test: /\.(png|jpe?g|gif)/i, loader: 'file-loader', options: { name: '[path][name].[ext]', outputPath: 'images' } },
        ],
    },
    resolve: {
        extensions: [ '.ts' ],
    },
    output: {
        path: path.resolve(__dirname, 'bundles'),
        filename: '[name].bundle.js',
    },
    plugins: [
        new miniCssExtractPlugin({ filename: "[name].bundle.css" }),
    ]
};