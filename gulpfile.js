/// <binding ProjectOpened='watch-sass, sass-compile' />
/*
This file in the main entry point for defining Gulp tasks and using Gulp plugins.
Click here to learn more. http://go.microsoft.com/fwlink/?LinkId=518007
*/

var gulp = require('gulp');
var sass = require('gulp-sass');
const PATH = "../GameX/wwwroot";
gulp.task('default', function () {
    // place code for your default task here
});

gulp.task('sass', function () {
    return gulp.src(`${PATH}/sass/**/*.scss`)
        .pipe(sass.sync().on('error', sass.logError))
        .pipe(gulp.dest(`${PATH}/css/`));
});


gulp.task('sass:watch', function () {
    gulp.watch(`${PATH}/sass/**/*.scss`, ['sass']);
});