/**
 * Add-on script for vue-cli-service serve to automaticaly pass
 * environment variables to app through cli
 */

const path = require('path');
const utils = require('./utils');
const parseArgs = require('minimist');
const util = require('util');
const exec = util.promisify(require('child_process').exec);
const { spawn } = require('child_process');

console.log('process.argv: ', process.argv);

async function main() {
    let argv = parseArgs(process.argv.slice(2));
    let {
        mode,
        environment,
    } = argv;
    console.log('argv:');
    console.dir(argv);

    // create env config file
    const targetPath = './'; // path where script is called (should be root of project where package.json is located)
    utils.createConfigEnvFile(mode, targetPath, {
        environment: environment,
    });

    // run vue cli serve
    let commandPath = path.join('./node_modules/.bin/vue-cli-service.cmd'); // fix Unix/Windows separator (/ vs \)
    let command = `${commandPath} serve --mode=${mode}`;

    console.log('command: ', command);

    // won't show stdout interactively
    // const { stdout, stderr } = await exec(command);
    // console.log('stdout:', stdout);
    // console.error('stderr:', stderr);

    // shows stdout interactively
    const child = spawn(commandPath, ['serve', '--mode', `${mode}`]);

    // use child.stdout.setEncoding('utf8'); if you want text chunks
    child.stdout.setEncoding('utf8');
    child.stderr.setEncoding('utf8');
    child.stdout.on('data', (chunk) => {
        // data from standard output is here as buffers
        // console.log(`stdout:`);
        console.log(chunk);
    });
    child.stderr.on('data', (data) => {
        // console.error(`stderr:`);
        console.error(data);
    });
    child.on('close', (code) => {
        console.log(`child process exited with code ${code}`);
    });
}

// top-level async function that never rejects
(async () => {
    try {
        await main();
    } catch (err) {
        // Deal with the fact the chain failed
        console.error(err);
    }
})();
