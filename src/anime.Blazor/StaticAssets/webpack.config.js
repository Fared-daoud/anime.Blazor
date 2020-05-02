const path = require('path');

module.exports = (env, args) => ({
  resolve: { extensions: ['.ts', '.js'] },
  devtool: args.mode === 'development' ? 'source-map' : 'none',
  module: {
    rules: [{ test: /\.ts?$/, loader: 'ts-loader' }]
  },
  entry: './animeBlazor.ts',
  output: {
    // Place output in wwwroot and export a top-level 'animeBlazor' object
    path: path.join(__dirname, '..', 'wwwroot'),
    filename: 'animeBlazor.js',
    libraryTarget: 'var',
    library: 'animeBlazor',
    libraryExport: 'default'
  }
});